using FluentEmail.Core;
using LearnTop.Modules.Identity.Application.Users.Services;

namespace LearnTop.Modules.Identity.Infrastructure.Users.Services;

public class EmailService(IFluentEmail fluentEmail) : IEmailService
{

    public async Task SendEmailAsync(string email, string subject, string message)
    {
        await fluentEmail
            .To(email)
            .Subject(subject)
            .Body(message)
            .SendAsync();
    }
}
