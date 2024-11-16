using FluentValidation;

namespace EngQuest.Application.Objectives.CompleteObjective;

public class CompleteObjectiveCommandValidator : AbstractValidator<CompleteObjectiveCommand>
{
    public CompleteObjectiveCommandValidator()
    {
        RuleFor(c => c.ObjectiveId).NotEmpty();
        RuleFor(c => c.Answer).NotEmpty();
    }   
}
