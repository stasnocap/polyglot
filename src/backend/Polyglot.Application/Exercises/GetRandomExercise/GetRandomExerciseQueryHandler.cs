using MediatR;
using Polyglot.Application.Abstractions.Messaging;
using Polyglot.Application.Exercises.GetExercise;
using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Exercises;
using Polyglot.Domain.Lessons;

namespace Polyglot.Application.Exercises.GetRandomExercise;

public class GetRandomExerciseQueryHandler(
    IExerciseRepository _exerciseRepository, 
    ILessonRepository _lessonRepository,
    ExerciseConverter _exerciseConverter) : IQueryHandler<GetRandomExerciseQuery, ExerciseResponse>
{
    public async Task<Result<ExerciseResponse>> Handle(GetRandomExerciseQuery request, CancellationToken cancellationToken)
    {
        Lesson? lesson = await _lessonRepository.GetAsync(request.LessonId, cancellationToken);

        if (lesson is null)
        {
            return Result.Failure<ExerciseResponse>(LessonErrors.NotFound);
        }

        Exercise exercise = await _exerciseRepository.GetRandomAsync(request.LessonId, cancellationToken);

        ExerciseResponse exerciseResult = await _exerciseConverter.ConvertAsync(exercise, lesson, cancellationToken);

        return exerciseResult;
    }
}
