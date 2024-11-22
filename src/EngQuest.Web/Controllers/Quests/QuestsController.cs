using Asp.Versioning;
using EngQuest.Application.Quests.GetQuests;
using EngQuest.Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EngQuest.Web.Controllers.Quests;

[ApiController]
[ApiVersion(ApiVersions.V1)]
[Route("api/v{version:apiVersion}/quests")]
public class QuestsController(ISender _sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetQuests(CancellationToken cancellationToken)
    {
        var query = new GetQuestsQuery();

        Result<IReadOnlyList<QuestResponse>> result = await _sender.Send(query, cancellationToken);

        if (result.IsFailure)
        {
            return StatusCode(500);
        }

        return Ok(result.Value);
    }
}
