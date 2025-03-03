using Email.DTOs;

namespace Email.Interfaces
{
    public interface IEmailService
    {
        Task<EmailRequestDto> CreateSendEmailAsync(EmailRequestDto requestDto);
    }
}
