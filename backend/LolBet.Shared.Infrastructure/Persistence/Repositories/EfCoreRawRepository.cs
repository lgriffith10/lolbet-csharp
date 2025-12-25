using LolBet.Shared.Domain.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LolBet.Shared.Infrastructure.Persistence.Repositories;

public class EfCoreRawRepository<TEntity>(AppDbContext dbContext) : IRawRepository<TEntity>
    where TEntity : class
{
    public IQueryable<TEntity> AsQueryable(CancellationToken cancellationToken = default)
    {
        return dbContext.Set<TEntity>().AsQueryable();
    }

    public IQueryable<TEntity> AsNoTrackingQueryable(CancellationToken cancellationToken = default)
    {
        return dbContext.Set<TEntity>().AsNoTracking();
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
    }
}