using System.Threading.Channels;
using EMemorandum.Jobs;

namespace EMemorandum.Services;

public interface IEmailQueueService
{
    void QueueEmailJob(EmailJob emailJob);
    Task<EmailJob> DequeueEmailJobAsync(CancellationToken cancellationToken);
}

public class EmailQueueService : IEmailQueueService
{
    private readonly Channel<EmailJob> _emailJobQueue;

    public EmailQueueService()
    {
        // Using a channel for thread-safe email queueing
        _emailJobQueue = Channel.CreateUnbounded<EmailJob>();
    }

    public void QueueEmailJob(EmailJob emailJob)
    {
        if (emailJob == null || string.IsNullOrEmpty(emailJob.Email))
        {
            throw new ArgumentNullException(nameof(emailJob), "Email or email job cannot be null.");
        }

        Console.WriteLine("aaa In Queue Email");
        
        // Queue the email (non-blocking)
        _emailJobQueue.Writer.TryWrite(emailJob);
    }

    public async Task<EmailJob> DequeueEmailJobAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("aaa In Dequeue Email");

        // Wait until an email is available to be dequeued
        var emailJob = await _emailJobQueue.Reader.ReadAsync(cancellationToken);

        Console.WriteLine($"aaa After Dequeue Email {emailJob.Email}");

        return emailJob;
    }
}
