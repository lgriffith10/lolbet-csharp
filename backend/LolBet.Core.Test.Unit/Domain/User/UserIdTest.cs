using LolBet.Domain.Aggregates.User;

namespace LolBet.Test.Unit.Domain.User;

public class UserIdTest
{
    [Fact]
    public void Create_ShouldSucceed()
    {
        // Act
        
        var id = Guid.NewGuid();
        
        // Arrange

        var result = UserId.Create(id);
        
        // Assert
        
        Assert.Equal(id, result.Value);
    }

    [Fact]
    public void Create_WithEmptyId_ShouldFail()
    {
        // Arrange
        
        var id = Guid.Empty;

        // Act
        
        var act = () => UserId.Create(id);

        // Assert
        
        var exception = Assert.Throws<ArgumentException>(act);
        Assert.Contains("Id cannot be empty", exception.Message);
    }
}