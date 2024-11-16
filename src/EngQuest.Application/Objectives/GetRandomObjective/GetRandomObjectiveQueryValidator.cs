using FluentValidation;

namespace EngQuest.Application.Objectives.GetRandomObjective;

public class GetRandomObjectiveQueryValidator : AbstractValidator<GetRandomObjectiveQuery>
{
    public GetRandomObjectiveQueryValidator()
    {
        RuleFor(x => x.QuestId).NotEmpty();
    }
}
