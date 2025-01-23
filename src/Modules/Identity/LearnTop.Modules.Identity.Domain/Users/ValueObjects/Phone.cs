using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Identity.Domain.Users.ValueObjects;

public record Phone
{
    public string PhoneNumber { get; private set; }
    public bool PhoneNumberVerified { get; internal set; }
    public int PhoneNumberVerifyCode { get; internal set; }

    public Phone(string phoneNumber)
    {
        PhoneNumber = phoneNumber;
    }
    
    public static implicit operator string(Phone phone) => phone.PhoneNumber;
    public static implicit operator Phone(string phoneNumber) => new(phoneNumber);
}
