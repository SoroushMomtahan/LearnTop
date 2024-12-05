namespace LearnTop.Shared.Domain;

/// <summary>
/// قالبی برای کلاس های موجودیت
/// </summary>
public abstract class Entity
{
    /// <summary>
    /// </summary>
    public Guid Id { get; private set; } = Guid.NewGuid();
    /// <summary>
    /// </summary>
    public DateTime CreatedAt { get; private set; } = DateTime.Now;
    /// <summary>
    /// </summary>
    public DateTime UpdatedAt { get; protected set; } = DateTime.Now;
    /// <summary>
    /// </summary>
    public DateTime DeletedAt { get; protected set; }
}
