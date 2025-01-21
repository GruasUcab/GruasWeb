using MediatR;


namespace GrúasUCAB.Core.Proveedores.Queries{

    public class GetConductorIdBySubQuery : IRequest<Guid?>
{
    public string Sub { get; set; }

    public GetConductorIdBySubQuery(string sub)
    {
        Sub = sub;
    }
}

}