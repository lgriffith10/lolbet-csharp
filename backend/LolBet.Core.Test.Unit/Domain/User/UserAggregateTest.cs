using LolBet.Domain.Aggregates.User;

namespace LolBet.Test.Unit.Domain.User;

public class UserAggregateTest
{
    [Fact]
    public void Create_User_ShouldSucceed()
    {
        // Act
        
        var userId = UserId.Create(Guid.NewGuid());
        
        // Arrange
        
        var result = UserAggregate.Create(userId);
        
        // Assert
        
        Assert.NotNull(result);
        
        Assert.Equal(userId, result.Id);
    }
}