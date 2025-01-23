namespace LearnTop.Modules.Identity.Domain.Users.ValueObjects;

public record Email(
    string EmailAddress)
{
    public string EmailAddress { get; private set; } = EmailAddress;
    public bool EmailVerified { get; internal set; }
    public int EmailVerifyCode { get; internal set; }
    
    public static implicit operator string(Email email) => email.EmailAddress;
    public static implicit operator Email(string emailAddress) => new(emailAddress);
}
