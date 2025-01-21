using GrúasUCAB.Core.Ordenes.Entities;
using GrúasUCAB.Core.Ordenes.Repositories;
using GrúasUCAB.Core.Proveedores.Repositories;

namespace GrúasUCAB.Core.Ordenes.Commands{

    public class EstadoOrdenMachine
{
    private readonly IOrdenDeServicioRepository _ordenDeServicioRepository;
    private readonly IConductorRepository _conductorRepository;

    public EstadoOrdenMachine(IOrdenDeServicioRepository ordenDeServicioRepository, IConductorRepository conductorRepository)
    {
        _ordenDeServicioRepository = ordenDeServicioRepository;
        _conductorRepository = conductorRepository;
    }

    // Método para manejar el cambio de estado
    public async Task Handle(AsignarOrdenCommand request, CancellationToken cancellationToken)
    {
        // Obtener la orden de servicio
        var orden = await _ordenDeServicioRepository.GetByIdAsync(request.OrdenId);
        if (orden == null)
        {
            throw new InvalidOperationException("La orden de servicio no existe.");
        }

        // Validar estado de la orden
        if (orden.Estado != EstadoOrden.Pendiente)
        {
            throw new InvalidOperationException("Solo se puede asignar un conductor si la orden está en estado 'Pendiente'.");
        }

        // Obtener la información del conductor
        var conductor = await _conductorRepository.GetByIdAsync(request.ConductorId);
        if (conductor == null)
        {
            throw new InvalidOperationException("El conductor no existe.");
        }

        // Asignar conductor, proveedor y ubicación
        orden.AsignarConductorYProveedor(
            request.ConductorId,
            conductor.ProveedorId,
            conductor.Latitud?? "",
            conductor.Longitud?? ""
        );

        // Cambiar estado a "Asignada"
        orden.CambiarEstado(EstadoOrden.Asignada);

        // Guardar cambios
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

