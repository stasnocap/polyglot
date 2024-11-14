using System.Threading.Tasks;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using EngQuest.Application.Exercises.CompleteExercise;
using EngQuest.Application.Exercises.GetExercise;
using EngQuest.Application.Exercises.GetRandomExercise;
using EngQuest.Domain.Abstractions;
using EngQuest.Domain.Lessons;

namespace EngQuest.Web.Controllers.Exercises;

[ApiController]
[ApiVersion(ApiVersions.V1)]
[Route("api/v{version:apiVersion}/exercises")]
public class ExercisesController(ISender _sender) : ControllerBase
{
    [HttpGet("random/{lessonId}")]
    public async Task<IActionResult> Random(int lessonId)
    {
        var query = new GetRandomExerciseQuery(lessonId);

        Result<ExerciseResponse> result = await _sender.Send(query, HttpContext.RequestAborted);

        return Ok(result.Value);
    }
    
    [HttpGet("{exerciseId}")]
    public async Task<IActionResult> GetById(int exerciseId, int lessonId)
    {
        var query = new GetExerciseQuery(exerciseId, lessonId);

        Result<ExerciseResponse> result = await _sender.Send(query, HttpContext.RequestAborted);

        return Ok(result.Value);
    }
    
    [HttpGet("{exerciseId}/complete")]
    public async Task<IActionResult> Complete(int exerciseId, int lessonId, string answer)
    {
        var command = new CompleteExerciseCommand(exerciseId, lessonId, answer);

        Result<CompleteExerciseResult> result = await _sender.Send(command, HttpContext.RequestAborted);

        return Ok(result.Value);
    }
}
