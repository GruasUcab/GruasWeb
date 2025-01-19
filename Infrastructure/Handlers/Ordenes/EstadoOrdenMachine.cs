using GrúasUCAB.Core.Ordenes.Entities;
using GrúasUCAB.Core.Ordenes.Repositories;

namespace GrúasUCAB.Core.Ordenes.Commands{

    public class EstadoOrdenMachine
{
    private readonly IOrdenDeServicioRepository _ordenDeServicioRepository;

    public EstadoOrdenMachine(IOrdenDeServicioRepository ordenDeServicioRepository)
    {
        _ordenDeServicioRepository = ordenDeServicioRepository;
    }

    // Método para manejar el cambio de estado
    public async Task AsignarConductorYProveedor(Guid ordenId, Guid conductorId, Guid proveedorId, string ubicacionConductor)
    {
        // Recuperamos la orden de servicio
        var orden = await _ordenDeServicioRepository.GetByIdAsync(ordenId);

        if (orden == null)
        {
            throw new InvalidOperationException("La orden de servicio no existe.");
        }

        // Solo permitimos asignar si está en el estado "Pendiente"
        if (orden.Estado != EstadoOrden.Pendiente)
        {
            throw new InvalidOperationException("Solo se puede asignar un conductor y proveedor en estado 'Pendiente'.");
        }

        // Asignamos el conductor y proveedor
        orden.AsignarConductorYProveedor(conductorId, proveedorId, ubicacionConductor);

        // Cambiamos el estado a "Asignada"
        orden.CambiarEstado(EstadoOrden.Asignada);

        // Guardamos los cambios en la base de datos
        await _ordenDeServicioRepository.UpdateAsync(orden);
    }

    // Método para cambiar el estado a "Completada"
    public async Task FinalizarOrden(Guid ordenId)
    {
        var orden = await _ordenDeServicioRepository.GetByIdAsync(ordenId);

        if (orden == null)
        {
            throw new InvalidOperationException("La orden de servicio no existe.");
        }

        // Solo permitimos finalizar si está en el estado "Asignada"
        if (orden.Estado != EstadoOrden.Asignada)
        {
            throw new InvalidOperationException("Solo se puede finalizar una orden en estado 'Asignada'.");
        }

        // Cambiamos el estado a "Completada"
        orden.CambiarEstado(EstadoOrden.Completada);

        // Guardamos los cambios
        await _ordenDeServicioRepository.UpdateAsync(orden);
    }

    // Método para cancelar la orden
    public async Task CancelarOrden(Guid ordenId)
    {
        var orden = await _ordenDeServicioRepository.GetByIdAsync(ordenId);

        if (orden == null)
        {
            throw new InvalidOperationException("La orden de servicio no existe.");
        }

        // Cambiamos el estado a "Cancelada"
        orden.CambiarEstado(EstadoOrden.Cancelada);

        // Guardamos los cambios
        await _ordenDeServicioRepository.UpdateAsync(orden);
    }
}

}

