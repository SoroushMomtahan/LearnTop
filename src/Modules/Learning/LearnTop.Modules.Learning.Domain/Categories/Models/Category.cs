using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Learning.Domain.Categories.Models;

public class Category : Aggregate
{
    public string Title { get; private set; }
    private readonly List<Item> _items = [];
    public IReadOnlyList<Item> Items => [.. _items];
}
