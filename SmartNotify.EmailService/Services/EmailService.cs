using SmartNotify.EmailService.Models;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

namespace SmartNotify.EmailService.Services
{
	public class EmailService : IEmailService
	{
		private readonly EmailSettings _emailSettings;

		public EmailService(IOptions<EmailSettings> options)
		{
			_emailSettings = options.Value;
		}

		public async Task SendEmailAsync(string to, string subject, string body)
		{
			var message = new MailMessage();
			message.To.Add(new MailAddress(to));
			message.From = new MailAddress(_emailSettings.SenderEmail, _emailSettings.SenderName);
			message.Subject = subject;
			message.Body = body;
			message.IsBodyHtml = true;

			using var client = new SmtpClient(_emailSettings.SmtpServer, _emailSettings.Port)
			{
				Credentials = new NetworkCredential(_emailSettings.UserName, _emailSettings.Password),
				EnableSsl = true
			};

			await client.SendMailAsync(message);
		}
	}
}
