namespace Polyglot.Domain.Users;

public sealed class User
{
    private readonly List<Role> _roles = [];
    
    public int Id { get; init; }

    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public Email Email { get; private set; }
    public string IdentityId { get; private set; } = string.Empty;

    public IReadOnlyList<Role> Roles => [.._roles];
    
    private User(FirstName firstName, LastName lastName, Email email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    // ReSharper disable once UnusedMember.Local
    private User()
    {
    }

    public static User Create(FirstName firstName, LastName lastName, Email email)
    {
        var user = new User(firstName, lastName, email);
        
        user._roles.Add(Role.Registered);

        return user;
    }

    public void SetIdentityId(string identityId)
    {
        IdentityId = identityId;
    }
}
