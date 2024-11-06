using Polyglot.Domain.Abstractions;
using Polyglot.Domain.Shared;

namespace Polyglot.Domain.Vocabulary.QuestionWords;

public sealed class QuestionWord : Entity
{
    public Text Text { get; }

    public QuestionWord(Guid id, Text text) : base(id)
    {
        Text = text;
    }

    // ReSharper disable once UnusedMember.Local
    private QuestionWord()
    {
    }
}
