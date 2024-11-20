using EngQuest.Domain.Abstractions;
using EngQuest.Domain.Objectives.Events;

namespace EngQuest.Domain.Objectives;

public sealed class Objective : Entity
{
    private readonly List<Word> _words = [];
    private readonly List<QuestId> _questIds = [];

    public RusPhrase RusPhrase { get; }
    public IReadOnlyList<Word> Words => _words.AsReadOnly();
    public IReadOnlyList<QuestId> QuestIds => _questIds.AsReadOnly();

    public Objective(RusPhrase rusPhrase)
    {
        RusPhrase = rusPhrase;
    }

    // ReSharper disable once UnusedMember.Local
    private Objective()
    {
    }

    public CompleteObjectiveResult Complete(string answer, int questId, int? userId)
    {
        string correctAnswer = string.Join(' ', Words.Select(x => x.Text.Value));

        var result = new CompleteObjectiveResult
        {
            Success = correctAnswer == answer,
            CorrectAnswer = correctAnswer
        };

        if (!result.Success || userId is null)
        {
            return result;
        }

        RaiseDomainEvent(new ObjectiveCompletedDomainEvent(questId, userId.Value));

        return result;
    }
}
