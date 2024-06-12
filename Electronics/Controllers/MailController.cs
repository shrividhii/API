using Common.Mail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Electronics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public MailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        [Route("SendMail")]
        public async Task<IActionResult> SendMail(MailRequest mailRequest)
        {
            try
            {
                await _emailService.SendEmail(mailRequest);
                return Ok(new { message = "Email sent successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while sending the email", details = ex.Message });
            }
        }
    }
}
