namespace EngQuest.Domain.Quests.Objectives;

public sealed class Objective
{
    private readonly List<Word> _words = [];
    
    public int Id { get; init; }
    public RusPhrase RusPhrase { get; }
    public IReadOnlyList<Word> Words => [.._words];
    
    public Objective(RusPhrase rusPhrase)
    {
        RusPhrase = rusPhrase;
    }
    
    // ReSharper disable once UnusedMember.Local
    private Objective()
    {
    }
}
