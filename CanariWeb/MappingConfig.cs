using AutoMapper;
using CanariaWeb.Models;
using CanariaWeb.Models.DTO;

namespace CanariaWeb
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<ApartmentDto, ApartmentCreateDto>().ReverseMap();
            CreateMap<ApartmentDto, ApartmentUpdateDto>().ReverseMap();

            CreateMap<ApartmentNumberDto, ApartmentNumberCreateDto>().ReverseMap();
            CreateMap<ApartmentNumberDto, ApartmentNumberUpdateDto>().ReverseMap();
        }
    }
}
