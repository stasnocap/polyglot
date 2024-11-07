using FluentValidation;

namespace Polyglot.Application.Vocabulary.Adjectives.DeleteAdjective;

public class DeleteAdjectiveCommandValidator : AbstractValidator<DeleteAdjectiveCommand>
{
    public DeleteAdjectiveCommandValidator()
    {
        RuleFor(a => a.Id).NotEmpty();
    }
}