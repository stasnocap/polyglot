using System.Diagnostics.CodeAnalysis;
using Polyglot.Application.Abstractions.Authentication;
using Polyglot.Application.Abstractions.Messaging;
using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Lessons;

namespace Polyglot.Application.Exercises.CompleteExercise;

public class CompleteExerciseCommandHandler(
    ILessonRepository _lessonRepository,
    IUserContext _userContext,
    IUnitOfWork _unitOfWork) : ICommandHandler<CompleteExerciseCommand, CompleteExerciseResult>
{
    [SuppressMessage("Security", "CA5394:Do not use insecure randomness")]
    public async Task<Result<CompleteExerciseResult>> Handle(CompleteExerciseCommand request, CancellationToken cancellationToken)
    {
        Lesson? lesson = await _lessonRepository.GetByIdAsync(request.LessonId, cancellationToken);

        if (lesson is null)
        {
            return Result.Failure<CompleteExerciseResult>(LessonErrors.NotFound);
        }

        int? userId = _userContext.UserId;

        Result<CompleteExerciseResult> completeExerciseResult = lesson.CompleteExercise(request.Answer, request.ExerciseId, userId);
        
        if (completeExerciseResult.IsFailure)
        {
            return completeExerciseResult;
        }
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return completeExerciseResult;
    }
}
