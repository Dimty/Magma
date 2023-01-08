using AutoMapper;
using Test_Practice_CSharp.DTO;

namespace Test_WebAPI.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ObjectsForJsonConversion.File, ErrorDTO>().ForMember(dto => dto.Errors,
                opt => opt.MapFrom(file => file.Errors.Select(x => x.ErrorMessage)));
        }
    }
}