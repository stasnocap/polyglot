using EngQuest.Domain.Shared;
using EngQuest.Domain.Abstractions;

namespace EngQuest.Domain.Vocabulary.QuestionWords;

public sealed class QuestionWord
{
    public int Id { get; init; }
    public Text Text { get; }

    public QuestionWord(Text text)
    {
        Text = text;
    }

    // ReSharper disable once UnusedMember.Local
    private QuestionWord()
    {
    }
}
