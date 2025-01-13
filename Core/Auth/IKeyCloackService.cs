using GrúasUCAB.Core.Usuarios.DTOs;

namespace GrúasUCAB.Core.Keycloak
{
    public interface IKeycloakService
{
    Task<string?> CreateUserAsync(string username, string email, string firstName, string lastName, string password);
    Task<bool> DeleteUserAsync(string userId);
    Task<string?> GetUserByUsernameAsync(string username);
    Task<bool> UpdateUserAsync(string userId, string email, string firstName, string lastName, bool enabled);
}
}
