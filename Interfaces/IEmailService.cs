using Email.DTOs;
using Email.Models;

namespace Email.Interfaces
{
    public interface IEmailService
    {
        
        Task<EmailResponseDto> SendEmailAsync(EmailDto email);
    }
}
