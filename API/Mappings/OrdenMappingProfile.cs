using AutoMapper;
using GrúasUCAB.Core.Ordenes.DTOs;
using GrúasUCAB.Core.Ordenes.Entities;
using GrúasUCAB.Core.Proveedores.Dto;
using GrúasUCAB.Core.Proveedores.DTO;
using GrúasUCAB.Core.Proveedores.Entities;


namespace GrúasUCAB.API.Mappings{
public class OrdenMappingProfile : Profile
{
    public OrdenMappingProfile()
    {
        CreateMap<Proveedor, ProveedorDTO>();
        CreateMap<Vehiculo, VehiculoDTO>();
        //CreateMap<CostoAdicional, CostoAdicionalDTO>();
        CreateMap<OrdenDeServicio, OrdenDeServicioDTO>();
            //.ForMember(dest => dest.CostosAdicionales, opt => opt.MapFrom(src => src.CostosAdicionales));
    }
}

}