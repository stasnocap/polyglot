using System.Diagnostics.CodeAnalysis;
using EngQuest.Application.Abstractions.Authentication;
using EngQuest.Application.Abstractions.Messaging;
using EngQuest.Domain.Abstractions;
using EngQuest.Domain.Quests;

namespace EngQuest.Application.Objectives.CompleteObjective;

public class CompleteObjectiveCommandHandler(
    IQuestRepository _questRepository,
    IUserContext _userContext,
    IUnitOfWork _unitOfWork) : ICommandHandler<CompleteObjectiveCommand, CompleteObjectiveResult>
{
    [SuppressMessage("Security", "CA5394:Do not use insecure randomness")]
    public async Task<Result<CompleteObjectiveResult>> Handle(CompleteObjectiveCommand request, CancellationToken cancellationToken)
    {
        Quest? quest = await _questRepository.GetByIdAsync(request.QuestId, cancellationToken);

        if (quest is null)
        {
            return Result.Failure<CompleteObjectiveResult>(QuestErrors.NotFound);
        }

        int? userId = _userContext.UserId;

        Result<CompleteObjectiveResult> completeObjectiveResult = quest.CompleteObjective(request.Answer, request.ObjectiveId, userId);
        
        if (completeObjectiveResult.IsFailure)
        {
            return completeObjectiveResult;
        }
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return completeObjectiveResult;
    }
}
