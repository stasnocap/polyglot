using System.Diagnostics.CodeAnalysis;
using MediatR;
using Polyglot.Application.Abstractions.Messaging;
using Polyglot.Application.Exercises.GetExercise;
using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Lessons;
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
#pragma warning disable CS9113 // Parameter is unread.

namespace Polyglot.Application.Exercises.GetRandomExercise;

[SuppressMessage("Major Code Smell", "S125:Sections of code should not be commented out")]
public class GetRandomExerciseQueryHandler(
    ILessonRepository _lessonRepository,
    ExerciseConverter _exerciseConverter) : IQueryHandler<GetRandomExerciseQuery, ExerciseResponse>
{
    public async Task<Result<ExerciseResponse>> Handle(GetRandomExerciseQuery request, CancellationToken cancellationToken)
    {
        // Lesson? lesson = await _lessonRepository.GetAsync(request.LessonId, cancellationToken);
        //
        // if (lesson is null)
        // {
        //     return Result.Failure<ExerciseResponse>(LessonErrors.NotFound);
        // }
        //
        // Exercise exercise = await _exerciseRepository.GetRandomAsync(request.LessonId, cancellationToken);
        //
        // ExerciseResponse exerciseResult = await _exerciseConverter.ConvertAsync(exercise, lesson, cancellationToken);
        //
        // return exerciseResult;

        return null;
    }
}
