using AutoMapper;
using GrúasUCAB.Core.Ordenes.DTOs;
using GrúasUCAB.Core.Ordenes.Entities;

public class OrdenDeServicioProfile : Profile
{
    public OrdenDeServicioProfile()
    {
        CreateMap<OrdenDeServicio, OrdenDeServicioDTO>();
    }
}
