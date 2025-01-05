using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Requests.Domain.Tickets.ViewModels;

public class TicketView : EntityView
{
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Status { get; set; }
    public string Priority { get; set; }
    public string Section { get; set; }
    public List<ReplyTicketView> ReplyTicketView { get; set; }
}
