using FluentValidation;

namespace EngQuest.Application.Objectives.GetObjective;

public class GetObjectiveQueryValidator : AbstractValidator<GetObjectiveQuery>
{
    public GetObjectiveQueryValidator()
    {
        RuleFor(q => q.ObjectiveId).NotEmpty();
        RuleFor(q => q.QuestId).NotEmpty();
    }
}
