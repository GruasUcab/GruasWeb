using FirebaseAdmin.Messaging;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("notificaciones")]
public class NotificacionesController : ControllerBase
{
    private static readonly Dictionary<string, List<string>> UsuarioTokens = new();

    // Endpoint para registrar un token de dispositivo
    [HttpPost("register")]
    public IActionResult RegistrarToken([FromBody] RegistrarTokenRequest request)
    {
        if (!UsuarioTokens.ContainsKey(request.UsuarioId))
        {
            UsuarioTokens[request.UsuarioId] = new List<string>();
        }

        if (!UsuarioTokens[request.UsuarioId].Contains(request.DeviceToken))
        {
            UsuarioTokens[request.UsuarioId].Add(request.DeviceToken);
        }

        return Ok(new { message = "Token registrado correctamente" });
    }

    // Endpoint para enviar una notificación a un usuario específico
    [HttpPost("enviar")]
    public async Task<IActionResult> EnviarNotificacion([FromBody] EnviarNotificacionRequest request)
    {
        if (!UsuarioTokens.TryGetValue(request.UsuarioId, out var tokens))
        {
            return NotFound(new { message = "No se encontraron tokens para el usuario" });
        }

        var message = new MulticastMessage
        {
            Tokens = tokens,
            Notification = new Notification
            {
                Title = request.Titulo,
                Body = request.Cuerpo
            },
            Data = request.Data
        };

        var response = await FirebaseMessaging.DefaultInstance.SendMulticastAsync(message);
        return Ok(new { message = "Notificación enviada", successCount = response.SuccessCount, failureCount = response.FailureCount });
    }

    // Endpoint para enviar notificaciones a todos los usuarios
    [HttpPost("enviar-todos")]
    public async Task<IActionResult> EnviarNotificacionATodos([FromBody] EnviarNotificacionATodosRequest request)
    {
        var tokens = UsuarioTokens.Values.SelectMany(x => x).ToList();
        if (!tokens.Any())
        {
            return BadRequest(new { message = "No hay tokens registrados" });
        }

        var message = new MulticastMessage
        {
            Tokens = tokens,
            Notification = new Notification
            {
                Title = request.Titulo,
                Body = request.Cuerpo
            },
            Data = request.Data
        };

        var response = await FirebaseMessaging.DefaultInstance.SendMulticastAsync(message);
        return Ok(new { message = "Notificaciones enviadas", successCount = response.SuccessCount, failureCount = response.FailureCount });
    }

    // Endpoint para eliminar un token de dispositivo
    [HttpDelete("token")]
    public IActionResult EliminarToken([FromBody] EliminarTokenRequest request)
    {
        if (UsuarioTokens.TryGetValue(request.UsuarioId, out var tokens))
        {
            tokens.Remove(request.DeviceToken);
            if (!tokens.Any())
            {
                UsuarioTokens.Remove(request.UsuarioId);
            }
        }

        return Ok(new { message = "Token eliminado correctamente" });
    }

    // Endpoint para obtener los tokens de un usuario
    [HttpGet("tokens/{usuarioId}")]
    public IActionResult ObtenerTokens(string usuarioId)
    {
        if (!UsuarioTokens.TryGetValue(usuarioId, out var tokens))
        {
            return NotFound(new { message = "No se encontraron tokens para el usuario" });
        }

        return Ok(new { usuarioId, tokens });
    }
}
