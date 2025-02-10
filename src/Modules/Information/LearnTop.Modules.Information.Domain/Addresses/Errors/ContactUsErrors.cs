using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Information.Domain.Addresses.Errors;

public static class ContactUsErrors
{
    public static Error NotFound(Guid id)
    {
        return new("ContactUs.NotFound", $"مخاطبی با شناسه {id} یافت نشد.", ErrorType.NotFound);
    }
}
