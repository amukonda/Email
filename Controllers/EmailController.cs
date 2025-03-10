using Email.DTOs;
using Email.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Email.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendEmail([FromBody] EmailRequestDto emailRequest)
        {
            if (emailRequest == null)
            {
                return BadRequest("Email request cannot be null.");
            }

            try
            {
                EmailResponseDto responseObj = await _emailService.SendEmailAsync(emailRequest);
               
                return Ok(responseObj.responseStatus);
            }
            catch (Exception ex)
            {
                // Log the exception (not shown here for brevity)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
