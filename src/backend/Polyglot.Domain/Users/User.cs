using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Users.Events;

namespace Polyglot.Domain.Users;

public sealed class User : Entity
{
    private readonly List<Role> _roles = [];
    private readonly List<Guid> _scoreIds = [];

    private User(Guid id, FirstName firstName, LastName lastName, Email email)
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    // ReSharper disable once UnusedMember.Local
    private User()
    {
    }

    public FirstName FirstName { get; private set; }

    public LastName LastName { get; private set; }

    public Email Email { get; private set; }

    public string IdentityId { get; private set; } = string.Empty;

    public IReadOnlyCollection<Role> Roles => [.._roles];
    
    public IReadOnlyCollection<Guid> ScoreIds => [.._scoreIds];

    public static User Create(FirstName firstName, LastName lastName, Email email)
    {
        var user = new User(Guid.NewGuid(), firstName, lastName, email);

        user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));

        user._roles.Add(Role.Registered);

        return user;
    }

    public void SetIdentityId(string identityId)
    {
        IdentityId = identityId;
    }
}
