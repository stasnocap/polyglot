using Polyglot.Application.Abstractions.Authentication;
using Polyglot.Application.Abstractions.Messaging;
using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Exercises;
using Polyglot.Domain.Scores;

namespace Polyglot.Application.Exercises.CompleteExercise;

public class CompleteExerciseCommandHandler(
    IExerciseRepository _exerciseRepository,
    IScoreRepository _scoreRepository,
    IUserContext _userContext,
    IUnitOfWork _unitOfWork) : ICommandHandler<CompleteExerciseCommand, CompleteExerciseResponse>
{
    public async Task<Result<CompleteExerciseResponse>> Handle(CompleteExerciseCommand request, CancellationToken cancellationToken)
    {
        string? answer = await _exerciseRepository.GetAnswerAsync(request.ExerciseId, cancellationToken);

        if (answer is null)
        {
            return Result.Failure<CompleteExerciseResponse>(ExerciseErrors.NotFound);
        }

        bool isCorrectAnswer = request.Answer == answer;

        Guid? currentUserId = _userContext.UserId;
        
        if (currentUserId is null)
        {
            return Result.Success(new CompleteExerciseResponse
            {
                Success = isCorrectAnswer,
                CorrectAnswer = answer,
                ExerciseId = request.ExerciseId
            });
        }

        Score? score = await _scoreRepository.GetAsync(request.LessonId, currentUserId.Value, cancellationToken);

        if (score is null)
        {
            score = Score.Create(Rating.Init(), currentUserId.Value, request.LessonId);
            _scoreRepository.Add(score);
        }

        if (isCorrectAnswer)
        {
            score.Rating.Increase();
        }
        else
        {
            score.Rating.Decrease();
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(new CompleteExerciseResponse
        {
            Success = isCorrectAnswer,
            CorrectAnswer = answer,
            ExerciseId = request.ExerciseId
        });
    }
}
