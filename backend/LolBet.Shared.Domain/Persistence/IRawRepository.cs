namespace LolBet.Shared.Domain.Persistence;

public interface IRawRepository<TEntity> 
    where TEntity : class
{
    IQueryable<TEntity> AsQueryable(CancellationToken cancellationToken = default);
    IQueryable<TEntity> AsNoTrackingQueryable(CancellationToken cancellationToken = default);
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
}