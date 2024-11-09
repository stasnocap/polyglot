using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Polyglot.Application.Exercises.GetExercise;
using Polyglot.Application.Exercises.GetRandomExercise;
using Polyglot.Domain.Abstractions;

namespace Polyglot.Web.Controllers.Exercises;

[ApiController]
[ApiVersion(ApiVersions.V1)]
[Route("api/v{version:apiVersion}/exercises")]
public class ExercisesController(ISender _sender) : ControllerBase
{
    [HttpGet("random/{lessonId}")]
    public async Task<IActionResult> Random(int lessonId, CancellationToken cancellationToken)
    {
        var query = new GetRandomExerciseQuery(lessonId);

        Result<ExerciseResponse> result = await _sender.Send(query, cancellationToken);

        return Ok(result.Value);
    }
}
