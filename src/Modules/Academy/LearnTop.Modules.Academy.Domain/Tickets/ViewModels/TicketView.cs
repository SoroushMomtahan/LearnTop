namespace LearnTop.Modules.Academy.Domain.Tickets.ViewModels;

public class TicketView
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Status { get; set; }
    public string Priority { get; set; }
    public string Section { get; set; }
    public List<ReplyTicketView> ReplyTicketView { get; set; }
}
