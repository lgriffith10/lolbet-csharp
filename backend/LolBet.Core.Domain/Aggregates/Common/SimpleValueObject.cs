namespace LolBet.Domain.Aggregates.Common;

public class SimpleValueObject<TType>
{
    public TType Value { get; private set; }
    
    protected SimpleValueObject(TType value)
    {
        Value = value;
    }
    
    public override string? ToString() => Value?.ToString();
}