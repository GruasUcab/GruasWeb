using GrúasUCAB.Core.Usuarios.Dto;
using GrúasUCAB.Core.Keycloak.Entities;

namespace GrúasUCAB.Core.Keycloak
{
    public interface IKeycloakService
{
    Task<string?> CreateUserAsync(string username, string email, string firstName, string lastName, string password);
    Task<bool> DeleteUserAsync(string userId);
    Task<string?> GetUserByUsernameAsync(string username);
    Task<bool> UpdateUserAsync(string userId, string email, string firstName, string lastName, bool enabled);
    Task<string> CreateUserWithRoleAsync(string username, string email, string firstName, string lastName, string password, List<string> roles);
    Task AssignRealmRolesAsync(string userId, List<string> roles);
    Task<List<KeycloakRole>> GetRealmRolesAsync();


}
}
