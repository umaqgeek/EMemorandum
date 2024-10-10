using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EMemorandum.Services;

public interface IEmailService
{
    Task SendEmailAsync(string toEmail, string subject, string body);
}

public class EmailService : IEmailService
{
    private readonly SmtpClient _smtpClient;
    private readonly string _fromEmail;

    public EmailService(IConfiguration configuration)
    {
        var smtpSettings = configuration.GetSection("SmtpSettings");
        _fromEmail = smtpSettings["FromEmail"];
        _smtpClient = new SmtpClient(smtpSettings["Host"])
        {
            Port = int.Parse(smtpSettings["Port"]),
            Credentials = new NetworkCredential(smtpSettings["Username"], smtpSettings["Password"]),
            EnableSsl = true
        };
    }

    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        try
        {
            var fromAddress = new MailAddress(_fromEmail);
            var toAddress = new MailAddress(toEmail);

            var mailMessage = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            await _smtpClient.SendMailAsync(mailMessage);
            Console.WriteLine("Email sent successfully.");
        }
        catch (SmtpFailedRecipientException ex)
        {
            Console.WriteLine($"Failed recipient: {ex.FailedRecipient}, Status: {ex.StatusCode}");
            // Handle failed recipient
        }
        catch (SmtpException ex)
        {
            // This catches general SMTP-related exceptions, such as connection problems.
            Console.WriteLine($"SMTP Exception: {ex.Message} (Status Code: {ex.StatusCode})");
            // You can log details, retry, etc.
        }
        catch (Exception ex)
        {
            // This catches any other general exceptions
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

