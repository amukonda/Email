using AutoMapper;
using Email.DTOs;
using Email.Models;

namespace Email.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmailDto, BccRecipient>()
            .ForMember(dest => dest.EmailId, opt => opt.MapFrom(src => src.Id ?? 1));


            //CreateMap<Request, RequestDto>(); // Define your mappings here
            //CreateMap<RequestDescriptionDto, RequestDescriptions>(); // Define your mappings here
            //CreateMap<RequestDescriptions, RequestDescriptionDto>(); // Define your mappings here
        }
    }
}
