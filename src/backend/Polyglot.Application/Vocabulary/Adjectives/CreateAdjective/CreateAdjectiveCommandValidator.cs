using FluentValidation;

namespace Polyglot.Application.Vocabulary.Adjectives.CreateAdjective;

public class CreateAdjectiveCommandValidator : AbstractValidator<CreateAdjectiveCommand>
{
    public CreateAdjectiveCommandValidator()
    {
        RuleFor(c => c.Text).NotEmpty();
    }   
}