using FluentValidation;

namespace Polyglot.Application.Exercises.GetRandomExercise;

public class GetRandomExerciseQueryValidator : AbstractValidator<GetRandomExerciseQuery>
{
    public GetRandomExerciseQueryValidator()
    {
        RuleFor(x => x.LessonId).NotEmpty();
    }
}
