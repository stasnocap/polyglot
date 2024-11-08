using FluentAssertions;
using Polyglot.Domain.UnitTests.Infrastructure;
using Polyglot.Domain.Users;

namespace Polyglot.Domain.UnitTests.Users;

public class UserTests
{
    [Fact]
    public void Create_Should_SetPropertyValue()
    {
        // Act
        var user = User.Create(UserData.FirstName, UserData.LastName, UserData.Email);

        // Assert
        user.FirstName.Should().Be(UserData.FirstName);
        user.LastName.Should().Be(UserData.LastName);
        user.Email.Should().Be(UserData.Email);
    }

    [Fact]
    public void Create_Should_AddRegisteredRoleToUser()
    {
        // Act
        var user = User.Create(UserData.FirstName, UserData.LastName, UserData.Email);

        // Assert
        user.Roles.Should().Contain(Role.Registered);
    }
}
