using LearnTop.Modules.Identity.Domain.Users.ValueObjects;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Identity.Domain.Users.Models;

public class Mobile : Entity
{
    public Guid UserId { get; private set; }
    public string Number { get; private set; }
    public Verify Verify { get; private set; }
    private Mobile() { }
    
    public static Mobile Create(string number)
    {
        return new()
        {
            Number = number,
            Verify = Verify.Create()
        };
    }
    public void ChangeNumber(string newNumber)
    {
        Number = newNumber;
        UpdatedAt = DateTime.Now;
    }
    public void ChangeVerifyStatus(bool verified)
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
