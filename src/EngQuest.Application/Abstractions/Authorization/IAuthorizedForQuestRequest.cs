using EngQuest.Application.Abstractions.Messaging;

namespace EngQuest.Application.Abstractions.Authorization;

public interface IAuthorizedForQuestRequest<TResponse> : IAuthorizedForQuestRequest, IQuery<TResponse>, ICommand<TResponse>;

public interface IAuthorizedForQuestRequest
{
    int QuestId { get; }
    
    static readonly int[] AllowedUnauthorizedQuests = [1];
}
