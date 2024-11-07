using FluentValidation;

namespace Polyglot.Application.Exercises.CompleteExercise;

public class CompleteExerciseCommandValidator : AbstractValidator<CompleteExerciseCommand>
{
    public CompleteExerciseCommandValidator()
    {
        RuleFor(c => c.ExerciseId).NotEmpty();
        RuleFor(c => c.Answer).NotEmpty();
    }   
}
