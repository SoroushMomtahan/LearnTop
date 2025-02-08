using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Identity.Domain.Roles.Errors;

public static class RoleErrors
{
    public static readonly Error PermissionNotFound = new(
        "Roles.PermissionNotFound", 
        "سطح دسترسی مورد نظر یافت نشد.",
        ErrorType.NotFound);
    
    public static readonly Error RoleNotFound = new(
        "Roles.RoleNotFound", 
        "نقش مورد نظر یافت نشد.",
        ErrorType.NotFound);
    public static readonly Error PermissionAlreadyExist = new(
        "Roles.PermissionAlreadyExist", 
        "نقش مورد نظر سطح دسترسی مربوطه را از قبل دارد.",
        ErrorType.Conflict);
}
