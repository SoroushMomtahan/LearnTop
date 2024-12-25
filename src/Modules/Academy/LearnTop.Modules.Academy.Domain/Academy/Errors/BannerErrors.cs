using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Academy.Domain.Academy.Errors;

public static class BannerErrors
{
    public static Error NotFound(Guid id)
    {
        return new("Banner.NotFound", $"بنری با شناسه {id} یافت نشد.", ErrorType.NotFound);
    }
}
