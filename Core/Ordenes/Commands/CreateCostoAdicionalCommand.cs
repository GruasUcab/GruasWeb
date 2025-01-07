using MediatR;

namespace GrúasUCAB.Core.Ordenes.Commands{
public class CreateCostoAdicionalCommand : IRequest<Guid>
{
    public string Nombre { get; set; } = null!;
    public string Descripcion {get; set; }
    public decimal Monto { get; set; }
    public Guid OrdenId { get; set; }

    public CreateCostoAdicionalCommand(string nombre, string descripcion, decimal monto, Guid ordenId)
    {
        Nombre = nombre;
        Descripcion = descripcion;
        Monto = monto;
        OrdenId = ordenId;
        
    }
}
}
