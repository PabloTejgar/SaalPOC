using AutoMapper;
using Saal.API.DTO.Request;
using Saal.API.DTO.Response;
using Saal.API.Models;

namespace Saal.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Restaurant mappings.
            CreateMap<RestaurantRequest, Restaurant>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.CityId));

            CreateMap<Restaurant, RestaurantResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone));
            CreateMap<Restaurant, RestaurantResponse>().ReverseMap();

            // City mappings.
            CreateMap<City, CityResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Restaurants, opt => opt.MapFrom(src => src.Restaurants));
            CreateMap<City, CityResponse>().ReverseMap()
                .ForMember(dest => dest.Restaurants, opt => opt.MapFrom(src => src.Restaurants));
        }
    }
}
