

namespace GrúasUCAB.Core.Keycloak.Entities{

    public class KeycloakRole
{
    public string Id { get; set; } = string.Empty; // ID del rol
    public string Name { get; set; } = string.Empty; // Nombre del rol
    public string? Description { get; set; } = string.Empty; // Descripción del rol (opcional)
    public bool Composite { get; set; } // Indica si es un rol compuesto
    public bool ClientRole { get; set; } // Indica si es un rol de cliente
    public string ContainerId { get; set; } = string.Empty; // ID del contenedor
}

}