
using System.Net;
using System.Net.Mail;

namespace MusicCloud.API.Services.Implements
{
	public class EmailService : IEmailService
	{
		private readonly IConfiguration configuration;

		public Task SendEmailAsync(string toEmail, string subject, string body, bool isBodyHtml)
		{
			string MailServer = configuration["Email:MailServer"];
			int Port = int.Parse(configuration["Email:MailPort"]);
			string FromMail = configuration["Email:FromMail"];
			string Password = configuration["Password"];

			var client = new SmtpClient(MailServer, Port)
			{
				Credentials = new NetworkCredential(FromMail, Password),
				EnableSsl = true
			};

			MailMessage message = new MailMessage(FromMail, toEmail, subject, body)
			{
				IsBodyHtml = isBodyHtml
			};

			return client.SendMailAsync(message);
		}
	}
}
