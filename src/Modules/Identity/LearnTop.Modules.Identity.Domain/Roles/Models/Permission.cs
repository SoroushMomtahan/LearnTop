namespace LearnTop.Modules.Identity.Domain.Roles.Models;

public class Permission(string application, string type, string description)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Application { get; private set; } = application;
    public string Type { get; private set; } = type;
    public string Description { get; private set; } = description;

    public static readonly Permission ReadDeletedArticles = new("Articles", "Read-Deleted", "خواندن مقالات");
    public static readonly Permission WriteArticles = new("Articles", "Write", "ایجاد مقالات");
    public static readonly Permission WriteTags = new("Tags", "Write", "ایجاد تگ های جدید");
    public static readonly Permission DeleteTags = new("Tags", "Delete", "حذف تگ ها");
    
}
