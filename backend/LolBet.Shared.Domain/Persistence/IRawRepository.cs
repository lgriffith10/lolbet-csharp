namespace LolBet.Shared.Domain.Persistence;

public interface IRawRepository<TEntity> 
    where TEntity : class
{
    Task<TEntity> AsQueryable(CancellationToken cancellationToken = default);
    Task<TEntity> AsNoTrackingQueryable(CancellationToken cancellationToken = default);
}