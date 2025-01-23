using MediatR;
using GrúasUCAB.Core.Ordenes.Commands;
using GrúasUCAB.Core.Ordenes.Repositories;



namespace Infrastructure.Handlers.Ordenes
{
    public class CostoFinalCommandHandler : IRequestHandler<CostoFinalCommand, Unit>
    {
        private readonly IOrdenDeServicioRepository _ordenServicioRepository;
        private readonly IPolizaRepository  _polizaRepository;
        private readonly IVehiculoAseguradoRepository  _vehiculoAseguradoRepository;
        private readonly ICostoAdicionalRepository _costoAdicionalRepository;
        public CostoFinalCommandHandler(IOrdenDeServicioRepository ordenServicioRepository, IPolizaRepository polizaRepository, IVehiculoAseguradoRepository vehiculoAseguradoRepository, ICostoAdicionalRepository costoAdicionalRepository)
        {
            _ordenServicioRepository = ordenServicioRepository;            
            _polizaRepository = polizaRepository;
            _vehiculoAseguradoRepository = vehiculoAseguradoRepository;
            _costoAdicionalRepository = costoAdicionalRepository;
        }

        public async Task<Unit> Handle(CostoFinalCommand request, CancellationToken cancellationToken)
        {















            var ordenServicio = await _ordenServicioRepository.GetByIdAsync(request.OrdenId);
            if (ordenServicio == null)
            {
                throw new KeyNotFoundException("La orden de servicio no existe.");
            }

            var vehiculoAsegurado = await _vehiculoAseguradoRepository.GetByIdAsync(ordenServicio.VehiculoAseguradoId);

            if(vehiculoAsegurado == null)
            {
                throw new KeyNotFoundException("El vehiculo asegurado no existe.");
            }

            var poliza = await _polizaRepository.GetByIdAsync(vehiculoAsegurado.PolizaId);

            if (poliza == null)
            {
                throw new KeyNotFoundException("La poliza no existe.");
            }

            var latitudConductor = ordenServicio.LatitudConductor;
            var longitudConductor = ordenServicio.LongitudConductor;
            var latitudIncidente = ordenServicio.LatitudIncidente;
            var longitudIncidente = ordenServicio.LongitudIncidente;
            
            
            
            var costosAdicionales = await _costoAdicionalRepository.GetByOrdenIdAsync(request.OrdenId);

            

            // Calcular el costo base
            var kilometrosExtras = ordenServicio.KilometrosRecorridos - poliza.KilometrosIncluidos; // Cobertura de 30 km
            var costoPorKilometrosExtras = kilometrosExtras > 0 ? kilometrosExtras * poliza.CostoXKilometro : 0; // $2 por km adicional

            var costoAdicional = costosAdicionales?.Sum(x => x.Monto) ?? 0;
            // Calcular el costo total
            var costoTotal = costoPorKilometrosExtras + costoAdicional;

            // Actualizar la orden de servicio
            ordenServicio.CostoTotal = costoTotal ?? 0;
            ordenServicio.CostoBase = costoPorKilometrosExtras;
            
            await _ordenServicioRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}