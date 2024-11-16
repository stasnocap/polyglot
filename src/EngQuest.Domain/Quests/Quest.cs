using EngQuest.Domain.Abstractions;
using EngQuest.Domain.Quests.Objectives;
using EngQuest.Domain.Quests.Scores;

namespace EngQuest.Domain.Quests;

public sealed class Quest
{
    private readonly List<QuestObjective> _objectives = [];
    private readonly List<Score> _scores = [];

    public int Id { get; init; }
    public QuestName Name { get; }

    public IReadOnlyList<QuestObjective> Objectives => [.._objectives];
    public IReadOnlyList<Score> Scores => [.._scores];

    public Quest(QuestName name)
    {
        Name = name;
    }

    // ReSharper disable once UnusedMember.Local
    private Quest()
    {
    }

    public Result<CompleteObjectiveResult> CompleteObjective(string answer, int objectiveId, int? userId)
    {
        QuestObjective? questObjective = _objectives.Find(x => x.ObjectiveId == objectiveId);

        if (questObjective is null)
        {
            return Result.Failure<CompleteObjectiveResult>(QuestErrors.ObjectiveNotFound);
        }

        string correctAnswer = string.Join(' ', questObjective.Objective.Words.Select(x => x.Text.Value));

        bool isCorrectAnswer = correctAnswer == answer;

        var completeObjectiveResult = new CompleteObjectiveResult
        {
            Success = isCorrectAnswer,
            CorrectAnswer = correctAnswer,
        };

        if (userId is null)
        {
            return Result.Success(completeObjectiveResult);
        }

        Score? score = _scores.Find(x => x.UserId == userId);

        score ??= new Score(Rating.Init(), userId.Value);

        if (correctAnswer == answer)
        {
            score.Rating.Increase();
        }
        else
        {
            score.Rating.Decrease();
        }

        return Result.Success(completeObjectiveResult);
    }
}
