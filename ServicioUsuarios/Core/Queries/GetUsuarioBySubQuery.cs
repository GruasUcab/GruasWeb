using MediatR;

namespace GrúasUCAB.Core.Usuarios.Queries{

    public class GetUsuarioIdBySubQuery : IRequest<Guid?>
{
    public string Sub { get; set; }

    public GetUsuarioIdBySubQuery(string sub)
    {
        Sub = sub;
    }
}

}