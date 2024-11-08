using Polyglot.Application.Abstractions.Messaging;
using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Lessons;

namespace Polyglot.Application.Exercises.GetExercise;

public class GetExerciseQueryHandler(ILessonRepository _lessonRepository, ExerciseConverter _exerciseConverter) : IQueryHandler<GetExerciseQuery, ExerciseResponse>
{
    public async Task<Result<ExerciseResponse>> Handle(GetExerciseQuery request, CancellationToken cancellationToken)
    {
        Lesson? lesson = await _lessonRepository.GetByIdAsync(request.LessonId, cancellationToken);

        if (lesson is null)
        {
            return Result.Failure<ExerciseResponse>(LessonErrors.NotFound);
        }

        LessonExercise? exercise = lesson.Exercises.FirstOrDefault(x => x.ExerciseId == request.ExerciseId);

        if (exercise is null)
        {
            return Result.Failure<ExerciseResponse>(LessonErrors.ExerciseNotFound);
        }

        ExerciseResponse exerciseResponse = await _exerciseConverter.ConvertAsync(exercise.Exercise, lesson, cancellationToken);

        return exerciseResponse;
    }
}
