using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Academy.Domain.Tickets.Models;

public sealed class ReplyTicket : Entity
{
    public Guid UserId { get; private set; }
    public string Content { get; private set; }

    public ReplyTicket(Guid userId, string content)
    {
        UserId = userId;
        Content = content;
    }

    public void Edit(string content)
    {
        Content = content;
    }
}
