using FluentValidation;

namespace EngQuest.Application.Exercises.GetRandomExercise;

public class GetRandomExerciseQueryValidator : AbstractValidator<GetRandomExerciseQuery>
{
    public GetRandomExerciseQueryValidator()
    {
        RuleFor(x => x.LessonId).NotEmpty();
    }
}
