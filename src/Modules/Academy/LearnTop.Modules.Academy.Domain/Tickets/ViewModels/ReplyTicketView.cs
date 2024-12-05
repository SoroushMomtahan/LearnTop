namespace LearnTop.Modules.Academy.Domain.Tickets.ViewModels;

public class ReplyTicketView
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid TicketViewId { get; set; }
    public string Content { get; set; }
}
