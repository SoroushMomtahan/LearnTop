namespace LearnTop.Modules.Identity.Domain.Users.ValueObjects;

public record Verify
{
    public bool Status { get; private set; }
    public int Code { get; private set; }
    public DateTime ExpireIn { get; private set; }
    private Verify() {}
    public static Verify Create()
    {
        return new()
        {
            Status = false,
            Code = 0,
            ExpireIn = default
        };
    }
    public static Verify SetCode(int code, DateTime? expireIn = null)
    {
        return new()
        {
            Status = false,
            Code = code,
            ExpireIn = expireIn ?? DateTime.Now.AddMinutes(2)
        };
    }
    public static Verify SetStatus(bool status)
    {
        return new()
        {
            Status = status,
            Code = 0,
            ExpireIn = default
        };
    }
}
