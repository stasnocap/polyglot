using FluentValidation;

namespace EngQuest.Application.Exercises.GetExercise;

public class GetExerciseQueryValidator : AbstractValidator<GetExerciseQuery>
{
    public GetExerciseQueryValidator()
    {
        RuleFor(q => q.ExerciseId).NotEmpty();
        RuleFor(q => q.LessonId).NotEmpty();
    }
}
