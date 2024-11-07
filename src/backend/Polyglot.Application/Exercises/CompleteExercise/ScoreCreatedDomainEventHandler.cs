using MediatR;
using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Lessons;
using Polyglot.Domain.Scores.Events;
using Polyglot.Domain.Users;

namespace Polyglot.Application.Exercises.CompleteExercise;

public class ScoreCreatedDomainEventHandler(
    IUserRepository _userRepository,
    ILessonRepository _lessonRepository,
    IUnitOfWork _unitOfWork) : INotificationHandler<ScoreCreatedDomainEvent>
{
    public async Task Handle(ScoreCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        User user = await _userRepository.GetByIdAsync(notification.UserId, cancellationToken) 
                     ?? throw new Exception(UserErrors.NotFound.ToString());

        Result addScoreResult = user.AddScore(notification.ScoreId);

        if (addScoreResult.IsFailure)
        {
            throw new Exception(addScoreResult.Error.ToString());
        }

        Lesson lesson = await _lessonRepository.GetAsync(notification.LessonId, cancellationToken) 
                         ?? throw new Exception(LessonErrors.NotFound.ToString());

        lesson.AddScore(notification.ScoreId);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
