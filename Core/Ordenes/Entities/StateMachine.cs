using GrúasUCAB.Core.Ordenes.Entities;

namespace GrúasUCAB.Core.Ordenes.Entities{

    public class MaquinaDeEstados
{
    private readonly OrdenDeServicio _orden;

    public MaquinaDeEstados(OrdenDeServicio orden)
    {
        _orden = orden;
    }

    public void CambiarEstado(EstadoOrden nuevoEstado)
    {
        // Validar si la transición es válida
        switch (_orden.Estado)
        {
            case EstadoOrden.Pendiente:
                if (nuevoEstado == EstadoOrden.Asignada || nuevoEstado == EstadoOrden.Cancelada)
                {
                    _orden.CambiarEstado(EstadoOrden.Asignada);
                }
                else
                {
                    throw new InvalidOperationException("No se puede cambiar de estado.");
                }
                break;

            case EstadoOrden.Asignada:
                if (nuevoEstado == EstadoOrden.Completada || nuevoEstado == EstadoOrden.Cancelada)
                {
                    _orden.CambiarEstado(EstadoOrden.Completada);
                }
                else
                {
                    throw new InvalidOperationException("No se puede cambiar de estado.");
                }
                break;

            case EstadoOrden.Completada:
            case EstadoOrden.Cancelada:
                throw new InvalidOperationException("El estado no puede cambiarse después de completarse o cancelarse.");
            default:
                throw new InvalidOperationException("Estado inválido.");
        }
    }
}

}