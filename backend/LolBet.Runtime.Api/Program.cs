using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using LolBet.Core.Infrastructure.AggregateRepositories;
using LolBet.Domain.Repositories;
using LolBet.Shared.Domain.Aggregates;
using LolBet.Shared.Domain.Contracts;
using LolBet.Shared.Domain.Persistence;
using LolBet.Shared.Infrastructure.Contracts;
using LolBet.Shared.Infrastructure.Persistence;
using LolBet.Shared.Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(
        Assembly.Load("LolBet.Core.Application"),
        Assembly.Load("LolBet.Core.Infrastructure"),
        Assembly.Load("LolBet.Core.Domain"),
        Assembly.GetExecutingAssembly()
    );
});

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    var assemblies = new[]
    {
        typeof(Program).Assembly,
        typeof(AggregateRoot<>).Assembly,
        typeof(IUserAggregateRepository).Assembly,
        typeof(EfCoreAggregateRepository<,>).Assembly,
        typeof(EfCoreUnitOfWork).Assembly,
        typeof(UserAggregateRepository).Assembly
    };
    
    containerBuilder
        .RegisterGeneric(typeof(EfCoreRawRepository<>))
        .As(typeof(IRawRepository<>))
        .InstancePerLifetimeScope();

    containerBuilder.RegisterAssemblyTypes(assemblies)
        .Where(t =>
            t is { IsClass: true, IsAbstract: false, IsGenericTypeDefinition: false } &&
            t.GetInterfaces().Any(i =>
                i is { IsInterface: true, IsGenericType: false } &&
                assemblies.Contains(i.Assembly) &&
                i != typeof(IDisposable)))
        .AsImplementedInterfaces()
        .InstancePerLifetimeScope();


    containerBuilder.RegisterAssemblyTypes(assemblies)
        .AsClosedTypesOf(typeof(IRequestHandler<,>))
        .InstancePerLifetimeScope();
});


builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    options.UseNpgsql(connectionString, npgsqlOptions =>
        {
            npgsqlOptions.EnableRetryOnFailure(0);

            npgsqlOptions.MigrationsAssembly("LolBet.Runtime.Api");
            npgsqlOptions.CommandTimeout(30);
            npgsqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
        })
        .EnableSensitiveDataLogging(builder.Environment.IsDevelopment())
        .EnableDetailedErrors(builder.Environment.IsDevelopment());
});


builder.Services.AddHealthChecks()
    .AddNpgSql(
        builder.Configuration.GetConnectionString("DefaultConnection")!,
        name: "postgresql",
        timeout: TimeSpan.FromSeconds(3)
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();