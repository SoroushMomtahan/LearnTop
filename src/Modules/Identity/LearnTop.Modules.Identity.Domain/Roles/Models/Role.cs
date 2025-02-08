using LearnTop.Modules.Identity.Domain.Roles.Errors;
using LearnTop.Modules.Identity.Domain.Users.Models;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Identity.Domain.Roles.Models;

public class Role(string name) : Aggregate
{
    public string Name { get; private set; } = name;
    public bool IsActive { get; private set; }
    private readonly List<Permission> _permissions = [];
    public IReadOnlyList<Permission> Permissions => [.. _permissions];
    
    public static readonly Role Admin = new("Admin");
    public static readonly Role User = new("User");

    public void Activate()
    {
        IsActive = true;
    }
    public void Deactivate()
    {
        IsActive = false;
    }
    public Result AddPermission(Permission permission)
    {
        if (_permissions.Contains(permission))
        {
            return Result.Failure(RoleErrors.PermissionAlreadyExist);
        }
        _permissions.Add(permission);
        return Result.Success();
    }
    public void RemovePermission(Permission permission)
    {
        if (!_permissions.Contains(permission))
        {
            return;
        }
        _permissions.Remove(permission);
    }
}
