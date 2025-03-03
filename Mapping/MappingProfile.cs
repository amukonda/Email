using AutoMapper;
using Email.DTOs;
using Email.Models;

namespace Email.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmailRequestDto, BaseEmail>()
            .ForMember(dest => dest.From, opt => opt.MapFrom(src => src.From ?? "Source is missing"));


            //CreateMap<Request, RequestDto>(); // Define your mappings here
            //CreateMap<RequestDescriptionDto, RequestDescriptions>(); // Define your mappings here
            //CreateMap<RequestDescriptions, RequestDescriptionDto>(); // Define your mappings here
        }
    }
}
