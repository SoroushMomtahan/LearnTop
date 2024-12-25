using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Academy.Domain.Academy.Errors;

public static class AcademyInfoErrors
{
    public static Error NotFound(Guid id)
    {
        return new("AcademyInfo.NotFound", $"اطلاعاتی با شناسه {id} از آکادمی یافت نشد.", ErrorType.NotFound);
    }
    public static Error FullnameIsEmpty()
    {
        return new("Academy.AcademyInfo", "حتما باید مقداری برای نام کامل وجود داشته باشد.", ErrorType.Validation);
    }
}
