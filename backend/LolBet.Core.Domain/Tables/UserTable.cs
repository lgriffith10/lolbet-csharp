using LolBet.Shared.Domain.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LolBet.Domain.Tables;

public class UserTable : IEntity
{
    public Guid Id { get; set; }
}

public class UserTableConfiguration : IEntityTypeConfiguration<UserTable>
{
    public void Configure(EntityTypeBuilder<UserTable> builder)
    {
        builder.HasKey(x => x.Id);
    }
}