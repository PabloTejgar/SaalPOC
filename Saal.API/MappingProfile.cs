using AutoMapper;
using Saal.API.DTO.Response;
using Saal.API.Models;

namespace Saal.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Restaurant, RestaurantResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City.Name))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone));
            CreateMap<Restaurant, RestaurantResponse>().ReverseMap();
        }
    }
}
