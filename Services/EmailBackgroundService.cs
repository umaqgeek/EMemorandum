using EMemorandum.Models;
using EMemorandum.Jobs;

namespace EMemorandum.Services;

public class EmailBackgroundService : BackgroundService
{
    private readonly IEmailQueueService _emailQueueService;
    private readonly IEmailService _emailService;

    public EmailBackgroundService(IEmailQueueService emailQueueService, IEmailService emailService)
    {
        _emailQueueService = emailQueueService;
        _emailService = emailService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("aaa Email background service is starting.");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                Console.WriteLine("aaa Background service is running and ready to process emails.");

                var emailJob = await _emailQueueService.DequeueEmailJobAsync(stoppingToken);
                await SendEmailAsync(emailJob);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Email background service is stopping due to cancellation.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while sending email.");
            }
        }

        Console.WriteLine("Email background service is stopping.");
    }

    private async Task SendEmailAsync(EmailJob emailJob)
    {
        try
        {
            Console.WriteLine("aaa Start sending email");
            await _emailService.SendEmailAsync(emailJob.Email, emailJob.Subject, emailJob.Body);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to send email to {emailJob.Email}");
        }
    }
}
