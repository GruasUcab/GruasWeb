using MediatR;

namespace GrúasUCAB.Core.Ordenes.Commands{

    public class UpdateCostoAdicionalCommand : IRequest<Unit>
{
    public Guid Id {get; set; }
    public string Nombre { get; set; } = null!;
    public string Descripcion {get; set; }
    public decimal Monto { get; set; }

    public UpdateCostoAdicionalCommand(string nombre, string descripcion, decimal monto)
    {
        Nombre = nombre;
        Monto = monto;
        Descripcion = descripcion;
    }
}

}