using AutoMapper;
using CanariaApi.Models;
using CanariaApi.Models.DTO;

namespace CanariaApi
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Apartment, ApartmentDto>();
            CreateMap<ApartmentDto, Apartment>();

            CreateMap<Apartment, ApartmentCreateDto>().ReverseMap();
            CreateMap<Apartment, ApartmentUpdateDto>().ReverseMap(); 
        }
    }
}
