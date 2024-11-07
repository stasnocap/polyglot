namespace Polyglot.Api.Infrastructure.Authentication;

public sealed class AuthenticationOptions
{
    public string Authority { get; init; } = string.Empty;

    public bool RequireHttpsMetadata { get; init; }

    public string ClientId { get; init; } = string.Empty;
    
    public string ClientSecret { get; init; } = string.Empty;
}
