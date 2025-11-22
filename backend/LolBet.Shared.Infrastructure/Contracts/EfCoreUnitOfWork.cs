using LolBet.Shared.Domain.Contracts;
using LolBet.Shared.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore.Storage;

namespace LolBet.Shared.Infrastructure.Contracts;

public class EfCoreUnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    private IDbContextTransaction? _currentTransaction;
    
    public async Task BeginTransactionAsync(CancellationToken ct = default)
    {
        if (_currentTransaction is not null)
            return;
        
        _currentTransaction = await dbContext.Database.BeginTransactionAsync(ct);
    }

    public async Task CommitAsync(CancellationToken ct = default)
    {
        if (_currentTransaction is null)
            throw new InvalidOperationException("No transaction started.");

        try
        {
            await dbContext.SaveChangesAsync(ct);
            await _currentTransaction.CommitAsync(ct);
        }
        catch
        {
            await RollbackAsync(ct);
            throw;
        }
        finally
        {
            await _currentTransaction.DisposeAsync();
            _currentTransaction = null;
        }
    }

    public async Task RollbackAsync(CancellationToken ct = default)
    {
        if (_currentTransaction is null)
            return;

        await _currentTransaction.RollbackAsync();
        await _currentTransaction.DisposeAsync();
        _currentTransaction = null;
    }
    
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _currentTransaction?.Dispose();
        dbContext.Dispose();
    }
}