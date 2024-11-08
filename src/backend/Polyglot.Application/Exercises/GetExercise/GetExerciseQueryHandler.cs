using System.Diagnostics.CodeAnalysis;
using Polyglot.Application.Abstractions.Messaging;
using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Lessons;
using Polyglot.Domain.Lessons.Exercises;
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
#pragma warning disable CS9113 // Parameter is unread.

namespace Polyglot.Application.Exercises.GetExercise;

[SuppressMessage("Major Code Smell", "S125:Sections of code should not be commented out")]
public class GetExerciseQueryHandler(
    ILessonRepository _lessonRepository,
    ExerciseConverter _exerciseConverter) : IQueryHandler<GetExerciseQuery, ExerciseResponse>
{
    public async Task<Result<ExerciseResponse>> Handle(GetExerciseQuery request, CancellationToken cancellationToken)
    {
        // Exercise? exercise = await _exerciseRepository.GetAsync(request.ExerciseId, cancellationToken);
        //
        // if (exercise is null)
        // {
        //     return Result.Failure<ExerciseResponse>(ExerciseErrors.NotFound);
        // }
        //
        // Lesson? lesson = await _lessonRepository.GetAsync(request.LessonId, cancellationToken);
        //
        // if (lesson is null)
        // {
        //     return Result.Failure<ExerciseResponse>(LessonErrors.NotFound);
        // }
        //
        // ExerciseResponse exerciseResult = await _exerciseConverter.ConvertAsync(exercise, lesson, cancellationToken);

        return null!;
    }
}
