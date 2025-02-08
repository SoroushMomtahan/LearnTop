using LearnTop.Modules.Identity.Domain.Users.ValueObjects;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Identity.Domain.Users.Models;

public class Email : Entity
{
    public Guid UserId { get; private set; }
    public string Address { get; private set; }
    public Verify Verify { get; private set; }

    private Email() { }
    public static Email Create(string emailAddress)
    {
        return new()
        {
            Address = emailAddress,
            Verify = Verify.Create()
        };
    }
    public void ChangeAddress(string newEmailAddress)
    {
        Address = newEmailAddress;
        UpdatedAt = DateTime.Now;
    }
    public void ChangeVerifyStatus(bool verified = true)
    {
        Verify = Verify.SetStatus(verified);
        UpdatedAt = DateTime.Now;
    }
    public void SetVerifyCode(int code)
    {
        Verify = Verify.SetCode(code);
        UpdatedAt = DateTime.Now;
    }
}
