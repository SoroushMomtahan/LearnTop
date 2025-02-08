namespace LearnTop.Modules.Identity.Application.Users.Services;

public interface IEmailService
{
    Task SendEmailAsync(string email, string subject, string message);
}
