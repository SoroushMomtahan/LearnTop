namespace LearnTop.Modules.Requests.Application.Tickets.Abstractions;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
