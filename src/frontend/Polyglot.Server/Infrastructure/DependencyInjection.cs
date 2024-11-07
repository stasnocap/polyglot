using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Polyglot.Api.Infrastructure.Authentication;

namespace Polyglot.Api.Infrastructure;

public static class DependencyInjection
{
    public static void AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AuthenticationOptions>(configuration.GetSection("Authentication"));

        services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddOpenIdConnect();
        
        services.ConfigureOptions<OpenIdConnectOptionsSetup>();
    }
}
