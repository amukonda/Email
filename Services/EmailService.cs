using AutoMapper;
using Email.Data;
using Email.DTOs;
using Email.Interfaces;

namespace Email.Services
{
    public class EmailService : IEmailService
    {


        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
      
        public EmailService(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
           
        }


        public async Task<EmailRequestDto> CreateSendEmailAsync(EmailRequestDto requestDto)
        {
            

            return _mapper.Map<EmailRequestDto>(requestDto);
        }
    }
}
