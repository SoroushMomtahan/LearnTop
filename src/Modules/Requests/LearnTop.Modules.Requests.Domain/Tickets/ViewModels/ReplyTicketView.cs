using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Requests.Domain.Tickets.ViewModels;

public class ReplyTicketView : EntityView
{
    public Guid UserId { get; set; }
    public Guid TicketViewId { get; set; }
    public string Content { get; set; }
}
