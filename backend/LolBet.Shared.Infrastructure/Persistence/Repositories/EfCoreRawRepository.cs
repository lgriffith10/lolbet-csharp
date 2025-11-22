using Microsoft.EntityFrameworkCore;

namespace LolBet.Shared.Infrastructure.Persistence.Repositories;

public class EfCoreRawRepository<TEntity>(AppDbContext dbContext)
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
}