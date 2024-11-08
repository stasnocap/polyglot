using Polyglot.Application.Abstractions.Authentication;
using Polyglot.Application.Abstractions.Messaging;
using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Lessons;

namespace Polyglot.Application.Exercises.CompleteExercise;

public class CompleteExerciseCommandHandler(
    ILessonRepository _lessonRepository,
    IUserContext _userContext,
    IUnitOfWork _unitOfWork) : ICommandHandler<CompleteExerciseCommand, bool>
{
    public async Task<Result<bool>> Handle(CompleteExerciseCommand request, CancellationToken cancellationToken)
    {
        Lesson? lesson = await _lessonRepository.GetAsync(request.LessonId, cancellationToken);

        if (lesson is null)
        {
            return Result.Failure<bool>(LessonErrors.NotFound);
        }

        int? userId = _userContext.UserId;

        Result<bool> completeExerciseResult = lesson.CompleteExercise(request.Answer, request.ExerciseId, userId);

        if (completeExerciseResult.IsFailure)
        {
            return completeExerciseResult;
        }
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return completeExerciseResult;
    }
}
