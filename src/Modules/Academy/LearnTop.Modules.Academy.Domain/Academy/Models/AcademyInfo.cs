using LearnTop.Modules.Academy.Domain.Academy.Errors;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Academy.Domain.Academy.Models;

public class AcademyInfo : Entity
{
    public Guid AcademyId { get; private set; }
    public string Fullname { get; private set; }
    public string Address { get; private set; }
    public string Phone { get; private set; }
    public string Email { get; private set; }

    private AcademyInfo() { }
    public static AcademyInfo Create(string fullname, string address, string phone, string email)
    {
        AcademyInfo info = new()
        {
            Fullname = fullname,
            Address = address,
            Phone = phone,
            Email = email
        };
        return info;
    }
    public Result Update(string fullname, string address, string phone, string email)
    {
        if (string.IsNullOrWhiteSpace(fullname))
        {
            return Result.Failure(AcademyInfoErrors.FullnameIsEmpty());
        }
        
        Fullname = fullname;
        Address = address;
        Phone = phone;
        Email = email;
        UpdatedAt = DateTime.UtcNow;
        return Result.Success();
    }
    public void Delete()
    {
        DeletedAt = DateTime.UtcNow;
    }
}
