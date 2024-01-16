using AutoMapper;
using Domain.Models;

namespace WebApi.Utilities;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        //CreateMap<Estacion, EstacionDto>()
        //    .ForMember(
        //        to => to.FechaHoraCreacion,
        //        opt => opt.MapFrom(from => from.FechaHoraCreacion.ToUniversalTime())
        //    );

        // TODO: Cambiar mapeo
        //CreateMap<EstacionDto, Estacion>()
        //    .ForMember(
        //        to => to.FechaHoraCreacion,
        //        opt => opt.MapFrom(from => from.FechaHoraCreacion.ToLocalTime())
        //    );

        //CreateMap<EstacionCreate, Estacion>()
        //    .ForMember(to => to.Id, opt => opt.MapFrom(opt => 0))
        //    .ForMember(
        //        to => to.FechaHoraCreacion,
        //        opt => opt.MapFrom(from => DateTime.Now.ToLocalTime())
        //    );
    }
}
