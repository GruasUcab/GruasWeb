using AutoMapper;
using GrúasUCAB.Core.Proveedores.Dto;
using GrúasUCAB.Core.Proveedores.DTO;
using GrúasUCAB.Core.Proveedores.Entities;

public class ProveedorMappingProfile : Profile
{
    public ProveedorMappingProfile()
    {
        CreateMap<Vehiculo, CreateVehiculoDTO>();
        CreateMap<CreateVehiculoDTO, Vehiculo>();
        CreateMap<Proveedor, ProveedorDTO>();
        CreateMap<Vehiculo, Proveedor>();
    }
}
