namespace LolBet.Shared.Domain.Aggregates;

public abstract class Entity<TId> : IEquatable<Entity<TId>> 
    where TId : notnull
{
    public TId Id { get; protected set; }

    public Entity(TId id)
    {
        Id = id ?? throw new ArgumentNullException(nameof(id));
    }

    public bool Equals(Entity<TId>? other)
    {
        if (other is null) return false;
        return ReferenceEquals(this, other) || EqualityComparer<TId>.Default.Equals(Id, other.Id);
    }

    public override bool Equals(object? obj)
    {
        return obj is Entity<TId> entity && Equals(entity);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
    
    public static bool operator ==(Entity<TId>? left, Entity<TId>? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Entity<TId>? left, Entity<TId>? right)
    {
        return !Equals(left, right);
    }
}