using Microsoft.AspNetCore.Mvc;
using SmartNotify.EmailService.Services;
using System.Threading.Tasks;

namespace SmartNotify.EmailService.Controllers
{
	[ApiController]
	[Route("api/email")]
	public class EmailController : ControllerBase
	{
		private readonly IEmailService _emailService;

		public EmailController(IEmailService emailService)
		{
			_emailService = emailService;
		}

		public class SendEmailRequest
		{
			public string To { get; set; }
			public string Subject { get; set; }
			public string Body { get; set; }
		}

		[HttpPost("send")]
		public async Task<IActionResult> Send([FromBody] SendEmailRequest request)
		{
			await _emailService.SendEmailAsync(request.To, request.Subject, request.Body);
			return Ok("Email sent successfully.");
		}
	}
}
