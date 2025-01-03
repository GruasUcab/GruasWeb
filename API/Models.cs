public class RegistrarTokenRequest
{
    public string UsuarioId { get; set; } = default!;
    public string DeviceToken { get; set; } = default!;
}

public class EnviarNotificacionRequest
{
    public string UsuarioId { get; set; } = default!;
    public string Titulo { get; set; } = default!;
    public string Cuerpo { get; set; } = default!;
    public Dictionary<string, string>? Data { get; set; }
}

public class EnviarNotificacionATodosRequest
{
    public string Titulo { get; set; } = default!;
    public string Cuerpo { get; set; } = default!;
    public Dictionary<string, string>? Data { get; set; }
}

public class EliminarTokenRequest
{
    public string UsuarioId { get; set; } = default!;
    public string DeviceToken { get; set; } = default!;
}
