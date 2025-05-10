using System.Threading.Tasks;

namespace SmartNotify.EmailService.Services
{
	public interface IEmailService
	{
		Task SendEmailAsync(string to, string subject, string body);
	}
}
