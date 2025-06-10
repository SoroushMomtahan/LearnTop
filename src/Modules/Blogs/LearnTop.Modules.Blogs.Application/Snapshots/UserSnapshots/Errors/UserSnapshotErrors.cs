using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Snapshots.UserSnapshots.Errors;

public static class UserSnapshotErrors
{
    public static Error NotFound(Guid userId)
    {
        return new(
            "UserSnapshots.NotFound", 
            $"کاربری با ناسه {userId} یافت نشد", 
            ErrorType.NotFound);
    }
}
