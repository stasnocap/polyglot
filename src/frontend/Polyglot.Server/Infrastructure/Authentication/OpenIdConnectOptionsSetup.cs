#pragma warning disable S125

using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Polyglot.Api.Infrastructure.Authentication;

public class OpenIdConnectOptionsSetup(IOptions<AuthenticationOptions> _authenticationOptions, IWebHostEnvironment _webHostEnvironment) : IConfigureNamedOptions<OpenIdConnectOptions>
{
    public void Configure(OpenIdConnectOptions options)
    {
        bool isDevelopment = _webHostEnvironment.IsDevelopment();

        options.RequireHttpsMetadata = _authenticationOptions.Value.RequireHttpsMetadata;
        options.Authority = _authenticationOptions.Value.Authority;
        // options.Authority = "http://localhost:18080/realms/polyglot";
        options.ClientId = _authenticationOptions.Value.ClientId;
        // options.ClientSecret = "RJimxkXfscfvi76sgDqiTpMQ0D63kL8b";
        options.ClientSecret = _authenticationOptions.Value.ClientSecret;
        options.ResponseType = "code";
        options.SaveTokens = true;
        options.Scope.Add("openid");
        options.TokenValidationParameters = new TokenValidationParameters
        {
            NameClaimType = "preferred_username",
            RoleClaimType = "roles",
        };

        // for (localhost - docker) authorization code flow to work
        if (isDevelopment)
        {
            options.TokenValidationParameters.ValidIssuer = "http://localhost:18080/realms/polyglot";
        }

        options.Events.OnRedirectToIdentityProvider = ctx =>
        {
            if (ctx.HttpContext.Request.Path != "/login")
            {
                ctx.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                ctx.HttpContext.Response.Headers["Location"] = "/login";
                ctx.HandleResponse();
            }
            else
            {
                // for (localhost - docker) authorization code flow to work
                if (isDevelopment)
                {
                    ctx.ProtocolMessage.IssuerAddress = "http://localhost:18080/realms/polyglot/protocol/openid-connect/auth";
                }
            }

            return Task.CompletedTask;
        };

        options.Events.OnRedirectToIdentityProviderForSignOut = (ctx) =>
        {
            // for (localhost - docker) authorization code flow to work
            if (isDevelopment)
            {
                ctx.ProtocolMessage.IssuerAddress = "http://localhost:18080/realms/polyglot/protocol/openid-connect/logout";
            }

            return Task.CompletedTask;
        };
    }

    public void Configure(string? name, OpenIdConnectOptions options)
    {
        Configure(options);
    }
}
