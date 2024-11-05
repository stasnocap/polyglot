using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Polyglot.Server.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    [HttpGet]
    [SuppressMessage("Security", "CA5394:Do not use insecure randomness")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            (
                Date: DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC: Random.Shared.Next(-20, 55),
                Summary: Summaries[Random.Shared.Next(Summaries.Length)]
            ))
            .ToArray();
    }
}
