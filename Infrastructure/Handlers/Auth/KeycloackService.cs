using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using GrúasUCAB.Core.Keycloak;


namespace GrúasUCAB.Infrastructure.Auth{
public class KeycloakService : IKeycloakService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    private string BaseUrl => _configuration["Keycloak:BaseUrl"]?? "";
    private string Realm => _configuration["Keycloak:Realm"]?? "";
    private string ClientId => _configuration["Keycloak:ClientId"]?? "";
    private string ClientSecret => _configuration["Keycloak:ClientSecret"]?? "";
    private string AdminUsername => _configuration["Keycloak:AdminUsername"]?? "";
    private string AdminPassword => _configuration["Keycloak:AdminPassword"]?? "";

    public KeycloakService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    private async Task<string?> GetAdminTokenAsync()
    {
        var tokenRequest = new Dictionary<string, string>
    {
        { "client_id", ClientId },
        { "client_secret", ClientSecret },        
        { "username", AdminUsername },
        { "password", AdminPassword },
        { "grant_type", "password" }
    };



        var response = await _httpClient.PostAsync($"{BaseUrl}/realms/{Realm}/protocol/openid-connect/token",
            new FormUrlEncodedContent(tokenRequest));
            //new StringContent(JsonSerializer.Serialize(tokenRequest), Encoding.UTF8, "application/json"));
            

        if (!response.IsSuccessStatusCode) return null;

        var jsonResponse = await response.Content.ReadAsStringAsync();
        var tokenData = JsonSerializer.Deserialize<JsonDocument>(jsonResponse);
        return tokenData?.RootElement.GetProperty("access_token").GetString();
    }

    public async Task<string?> CreateUserAsync(string username, string email, string firstName, string lastName, string password)
    {
        var token = await GetAdminTokenAsync();
        if (token == null) throw new InvalidOperationException("Failed to obtain Keycloak admin token.");

        var user = new
        {
            username,
            email,
            firstName,
            lastName,
            enabled = true,
            credentials = new[]
            {
                new { type = "password", value = password, temporary = false }
            }
        };

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.PostAsync($"{BaseUrl}/admin/realms/{Realm}/users",
            new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json"));
            Console.WriteLine($"Status Code: {response.StatusCode}");
            Console.WriteLine($"Response Content: {response}");

        if (!response.IsSuccessStatusCode) return null;

        var locationHeader = response.Headers.Location?.ToString();        
        if (string.IsNullOrEmpty(locationHeader))
        {
            throw new InvalidOperationException("No se pudo obtener el Location header de la respuesta de Keycloak.");
        }
        var userId = locationHeader.Split('/').LastOrDefault();
        if (string.IsNullOrEmpty(userId))
        {
            throw new InvalidOperationException("No se pudo extraer el userId del Location header.");
        }
        //return locationHeader?.Split('/').LastOrDefault(); // Extract User ID
        Console.WriteLine(userId);
        return userId;
    }

    public async Task<bool> DeleteUserAsync(string userId)
    {
        var token = await GetAdminTokenAsync();
        if (token == null) throw new InvalidOperationException("Failed to obtain Keycloak admin token.");

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.DeleteAsync($"{BaseUrl}/admin/realms/{Realm}/users/{userId}");
        return response.IsSuccessStatusCode;
    }

    public async Task<string?> GetUserByUsernameAsync(string username)
    {
        var token = await GetAdminTokenAsync();
        if (token == null) throw new InvalidOperationException("Failed to obtain Keycloak admin token.");

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.GetAsync($"{BaseUrl}/admin/realms/{Realm}/users?username={username}");
        if (!response.IsSuccessStatusCode) return null;

        var jsonResponse = await response.Content.ReadAsStringAsync();
        var users = JsonSerializer.Deserialize<JsonElement>(jsonResponse);
        return users[0].GetProperty("id").GetString(); // Assuming the username is unique
    }

    public async Task<bool> UpdateUserAsync(string userId, string email, string firstName, string lastName, bool enabled)
    {
        var token = await GetAdminTokenAsync();
        if (token == null) throw new InvalidOperationException("Failed to obtain Keycloak admin token.");

        var user = new
        {
            email,
            firstName,
            lastName,
            enabled
        };

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.PutAsync($"{BaseUrl}/admin/realms/{Realm}/users/{userId}",
            new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json"));

        return response.IsSuccessStatusCode;
    }
}
}