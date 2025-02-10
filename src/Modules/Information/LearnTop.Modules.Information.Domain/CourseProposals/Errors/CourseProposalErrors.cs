using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Information.Domain.CourseProposals.Errors;

public static class CourseProposalErrors
{
    public static Error TeacherNotFound(Guid userId)
    {
        return new("CourseProposals.TeacherNotFound", $"کاربری با شناسه ی {userId} یافت نشد", ErrorType.NotFound);
    }
}
