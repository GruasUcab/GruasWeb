using System.Net;
using GrúasUCAB.Core.Ordenes.Entities;
using GrúasUCAB.Core.Ordenes.Repositories;
using System.Text.Json;
using GrúasUCAB.Core.Ordenes.DTOs;
using System.Runtime.InteropServices;

namespace GrúasUCAB.Core.Ordenes.Commands{

    

    public class EstadoOrdenMachine
{
    private readonly IOrdenDeServicioRepository _ordenDeServicioRepository;
    private readonly ProveedoresService _proveedoresService;

    public EstadoOrdenMachine(
        IOrdenDeServicioRepository ordenDeServicioRepository,
        ProveedoresService proveedoresService)
    {
        _ordenDeServicioRepository = ordenDeServicioRepository;
        _proveedoresService = proveedoresService;
    }

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

        // Obtener la información del conductor desde el microservicio de proveedores
        var conductor = await _proveedoresService.ObtenerConductorAsync(request.ConductorId);
        if (conductor == null)
        {
            throw new InvalidOperationException("El conductor no existe.");
        }

        bool act = conductor.Activo;
        Console.Write(act);
        
        if (conductor == null || act == false)
        {
        throw new InvalidOperationException("El conductor no está disponible.");
        }

        
        
        // Asignar conductor, proveedor y ubicación
        orden.AsignarConductorYProveedor(
            request.ConductorId,
            conductor.ProveedorId,
            conductor.Latitud ?? "",
            conductor.Longitud ?? ""
        );
        var actualizado = await _proveedoresService.ActualizarEstadoConductorAsync(request.ConductorId, false);
        if (!actualizado)
        {
            throw new InvalidOperationException("No se pudo actualizar el estado del conductor en el servicio de proveedores.");
        }
        
        // Cambiar el estado del conductor
        //conductor.Activo = false;

        // Cambiar estado a "Asignada"
        orden.CambiarEstado(EstadoOrden.Asignada);

        // Guardar los cambios
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
        if (orden.Estado != EstadoOrden.Localizada)
        {
            throw new InvalidOperationException("Solo se puede finalizar una orden en estado 'Asignada'.");
        }        

        Guid conductorId = orden.ConductorId?? Guid.Empty;
        var actualizado = await _proveedoresService.ActualizarEstadoConductorAsync(conductorId, true);
        if (!actualizado)
        {
            throw new InvalidOperationException("No se pudo actualizar el estado del conductor en el servicio de proveedores.");
        }
        
        

        


        // Cambiamos el estado a "Completada"
        orden.CambiarEstado(EstadoOrden.Completada);

        // Guardamos los cambios
        await _ordenDeServicioRepository.UpdateAsync(orden);
        
        
    }

    public async Task LocalizarOrden(Guid ordenId)
    {
        var orden = await _ordenDeServicioRepository.GetByIdAsync(ordenId);

        if (orden == null)
        {
            throw new InvalidOperationException("La orden de servicio no existe.");
        }

        if (orden.Estado != EstadoOrden.Asignada)
        {
            throw new InvalidOperationException("Solo se puede finalizar una orden en estado 'Asignada'.");
        }  

        orden.CambiarEstado(EstadoOrden.Localizada);

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

        if (orden.Estado != EstadoOrden.Asignada || orden.Estado != EstadoOrden.Pendiente )
        {
            throw new InvalidOperationException("Solo se puede finalizar una orden en estado 'Asignada'.");
        }  
        Guid conductorId = orden.ConductorId?? Guid.Empty;

        var actualizado = await _proveedoresService.ActualizarEstadoConductorAsync(conductorId, true);
        if (!actualizado)
        {
            throw new InvalidOperationException("No se pudo actualizar el estado del conductor en el servicio de proveedores.");
        }
        

        // Cambiamos el estado a "Cancelada"
        orden.CambiarEstado(EstadoOrden.Cancelada);

        // Guardamos los cambios
        await _ordenDeServicioRepository.UpdateAsync(orden);
        
    }
}
}

//}

