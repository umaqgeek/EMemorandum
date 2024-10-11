using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EMemorandum.Services;

namespace EMemorandum.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
[Authorize(Policy = "TokenPolicy")]
public class EmailController : ControllerBase
{
    private readonly IEmailService _emailService;

    public EmailController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendEmail([FromBody] EmailRequest emailRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _emailService.SendEmailAsync(emailRequest.ToEmail, emailRequest.Subject, emailRequest.Body);
        return Ok(new { Message = "Email sent successfully!" });
    }
}

public class EmailRequest
{
    public string ToEmail { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
}
