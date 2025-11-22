using System.Reflection;
using LolBet.Shared.Domain.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LolBet.Shared.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        ApplyConfigurationsFromMultipleAssemblies(modelBuilder);
        RegisterEntitiesByConventionFromMultipleAssemblies(modelBuilder);
    }
    
    private void ApplyConfigurationsFromMultipleAssemblies(ModelBuilder modelBuilder)
    {
        var assembliesToScan = new[]
        {
            Assembly.GetExecutingAssembly(),
            Assembly.Load("LolBet.Core.Domain"),
        };

        foreach (var assembly in assembliesToScan)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }
    }

    private void RegisterEntitiesByConventionFromMultipleAssemblies(ModelBuilder modelBuilder)
    {
        var assemblies = new[]
        {
            Assembly.GetExecutingAssembly(),
            Assembly.Load("LolBet.Core.Domain"),
        };

        foreach (var assembly in assemblies)
        {
            var entityTypes = assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && typeof(IEntity).IsAssignableFrom(t));

            foreach (var type in entityTypes)
            {
                if (modelBuilder.Model.FindEntityType(type) is null)
                {
                    modelBuilder.Entity(type);
                }
            }
        }
    }
}