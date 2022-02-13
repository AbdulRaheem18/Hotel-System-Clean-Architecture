using AutoMapper;

using domain.entities;
using application.common;

using Hotel_Management_System.Model;
using application.Features.Hotels.DTO;
using application.Features.Hotel.DTO;

namespace application.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //CreateMap<SOURCE, DESTINATION>
             CreateMap<Hotel, Hoteldto>().
             ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src => src.ProfilePicture))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ReverseMap();

            CreateMap<Facility, Facilitiesdto>().
            ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
           .ForMember(dest => dest.Icon, opt => opt.MapFrom(src => src.Icon))
           .ReverseMap();






        }
    }
}