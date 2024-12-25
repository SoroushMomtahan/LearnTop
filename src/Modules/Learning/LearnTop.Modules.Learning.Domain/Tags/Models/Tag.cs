using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Learning.Domain.Tags.Models;

public class Tag : Aggregate
{
    public string Title { get; private set; }
}
