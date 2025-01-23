using System.Net.Http.Json;
using GrúasUCAB.Core.Ordenes.DTOs;

public class ProveedoresService
{
    private readonly HttpClient _httpClient;

    public ProveedoresService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ConductorDTO?> ObtenerConductorAsync(Guid conductorId)
    {
        var response = await _httpClient.GetAsync($"conductor/{conductorId}");

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<ConductorDTO>();
        }

        return null;
    }

    public async Task<bool> ActualizarEstadoConductorAsync(Guid conductorId, bool estado)
    {
        var response = await _httpClient.PutAsync(
            $"conductor/{conductorId}/estado?estado={estado}", 
            null // El cuerpo puede ser null, ya que solo se envía el estado como parámetro
        );

        return response.IsSuccessStatusCode;
    }

   
}