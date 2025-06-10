using LearnTop.Shared.Domain;

namespace LearnTop.Modules.People.Domain.Producers.Models;

public class Producer : Aggregate
{
    public Guid UserId { get; private set; }
    public string Bio { get; private set; }
    private readonly List<string> _socialMediaLinks = [];
    public IReadOnlyList<string> SocialMediaLinks => [.._socialMediaLinks];
    
    private Producer(){}
    public static Producer Create(string bio)
    {
        Producer producer = new()
        {
            UserId = Guid.NewGuid(),
            Bio = bio
        };
        return producer;
    }
}
