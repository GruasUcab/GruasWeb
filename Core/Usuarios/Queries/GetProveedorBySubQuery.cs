using MediatR;

namespace GrúasUCAB.Core.Usuarios.Queries{

    public class GetProveedorIdBySubQuery : IRequest<Guid?>
{
    public string Sub { get; set; }

    public GetProveedorIdBySubQuery(string sub)
    {
        Sub = sub;
    }
}

}