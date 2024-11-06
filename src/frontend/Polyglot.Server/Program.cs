using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
    })
    .AddCookie()
    .AddOpenIdConnect((options) =>
    {
        options.RequireHttpsMetadata = false;
        options.Authority = "http://localhost:8080/realms/myrealm";
        options.ClientId = "myclient";
#pragma warning disable S125
        // options.ClientSecret = "RJimxkXfscfvi76sgDqiTpMQ0D63kL8b";
#pragma warning restore S125
        options.ClientSecret = "hwk7GqcMe2cOEkqHAZji6RqI9DRMWe7I";
        options.ResponseType = "code";
        options.SaveTokens = true;
        options.Scope.Add("openid");
        options.TokenValidationParameters = new TokenValidationParameters
        {
            NameClaimType = "preferred_username",
            RoleClaimType = "roles"
        };

        options.Events.OnRedirectToIdentityProvider = RedirectOnlyOnLoginEndpoint;

        static Task RedirectOnlyOnLoginEndpoint(RedirectContext redirectContext)
        {
            if (redirectContext.HttpContext.Request.Path != "/login")
            {
                redirectContext.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                redirectContext.HttpContext.Response.Headers["Location"] = "/login";
                redirectContext.HandleResponse();
            }

            return Task.CompletedTask;
        }
    });

WebApplication app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

await app.RunAsync();
