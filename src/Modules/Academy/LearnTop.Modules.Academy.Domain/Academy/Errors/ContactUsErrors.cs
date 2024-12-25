using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Academy.Domain.Academy.Errors;

public static class ContactUsErrors
{
    public static Error NotFound(Guid id)
    {
        return new("ContactUs.NotFound", $"مخاطبی با شناسه {id} یافت نشد.", ErrorType.NotFound);
    }
}
