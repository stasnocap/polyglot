using EngQuest.Application.Abstractions.Authentication;
using EngQuest.Application.Abstractions.Authorization;
using EngQuest.Application.Abstractions.Caching;
using EngQuest.Application.Exceptions;
using EngQuest.Application.Levels.GetLevel;
using EngQuest.Domain.Abstractions;
using EngQuest.Domain.Levels;
using EngQuest.Domain.Users;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EngQuest.Application.Abstractions.Behaviors;

internal sealed class AuthorizeForQuestBehavior<TRequest, TResponse>(
    IUserContext _userContext,
    ILogger<AuthorizeForQuestBehavior<TRequest, TResponse>> _logger,
    ISender _sender) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IAuthorizedForQuestRequest
    where TResponse : Result
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        int? userId = _userContext.UserId;

        if (userId is null)
        {
            if (!IAuthorizedForQuestRequest.AllowedUnauthorizedQuests.Contains(request.QuestId))
            {
                return Forbidden(request, userId);
            }
        }
        else
        {
            Result<LevelResponse> result = await _sender.Send(new GetLevelQuery(userId.Value), cancellationToken);

            if (result.IsFailure)
            {
                throw new Exception(result.Error.ToString());
            }

            LevelResponse level = result.Value;

            if (level.Value < request.QuestId)
            {
                return Forbidden(request, userId);
            }
        }

        return await next();
    }

    private TResponse Forbidden(TRequest request, int? userId)
    {
        _logger.LogInformation("Access for quest {Quest} was denied for user {UserId}", request.QuestId, userId);
        throw new ForbiddenException(UserErrors.Forbidden);
    }
}
