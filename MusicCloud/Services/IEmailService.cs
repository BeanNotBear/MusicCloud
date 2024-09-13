namespace MusicCloud.API.Services
{
	public interface IEmailService
	{
		Task SendEmailAsync(string toEmail, string subject, string body, bool isBodyHtml);
	}
}
