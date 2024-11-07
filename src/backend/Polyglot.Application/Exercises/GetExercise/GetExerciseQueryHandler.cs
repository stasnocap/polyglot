using Polyglot.Application.Abstractions.Messaging;
using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Exercises;
using Polyglot.Domain.Lessons;

namespace Polyglot.Application.Exercises.GetExercise;

public class GetExerciseQueryHandler(
    IExerciseRepository _exerciseRepository,
    ILessonRepository _lessonRepository,
    ExerciseConverter _exerciseConverter) : IQueryHandler<GetExerciseQuery, ExerciseResponse>
{
    public async Task<Result<ExerciseResponse>> Handle(GetExerciseQuery request, CancellationToken cancellationToken)
    {
        Exercise? exercise = await _exerciseRepository.GetAsync(request.ExerciseId, cancellationToken);

        if (exercise is null)
        {
            return Result.Failure<ExerciseResponse>(ExerciseErrors.NotFound);
        }

        Lesson? lesson = await _lessonRepository.GetAsync(request.LessonId, cancellationToken);
        
        if (lesson is null)
        {
            return Result.Failure<ExerciseResponse>(LessonErrors.NotFound);
        }

        ExerciseResponse exerciseResult = await _exerciseConverter.ConvertAsync(exercise, lesson, cancellationToken);

        return exerciseResult;
    }
}
