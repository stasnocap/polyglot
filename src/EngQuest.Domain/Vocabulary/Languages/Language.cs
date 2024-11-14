using EngQuest.Domain.Shared;
using EngQuest.Domain.Abstractions;

namespace EngQuest.Domain.Vocabulary.Languages;

public sealed class Language
{
    public int Id { get; init; }
    public Text Text { get; }

    public Language(Text text)
    {
        Text = text;
    }
    
    // ReSharper disable once UnusedMember.Local
    private Language()
    {
    }
}
