using AutoMapper;
using Email.Data;
using Email.DTOs;
using Email.Interfaces;
using System.Xml.Serialization;

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
        public async Task<EmailResponseDto> SendEmailAsync(EmailRequestDto emailRequest)
        {
            // Logic to send email
            // This could involve using SMTP or any third-party email service
            string requestXML = emailRequest.Header.RequestXML;

            // Deserialize the XML
            EmailRequestDto request = DeserializeXml<EmailRequestDto>(requestXML);

            var emailResponse = new EmailResponseDto();
            emailResponse.responseStatus = "Email Sent Successfully.";
            return emailResponse;
        }

        public static T DeserializeXml<T>(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringReader reader = new StringReader(xml))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
