namespace Polyglot.Domain.Lessons.Exercises;

public sealed class Exercise
{
    private readonly List<Word> _words = [];
    
    public int Id { get; init; }
    public RusPhrase RusPhrase { get; }
    public IReadOnlyList<Word> Words => [.._words];
    
    public Exercise(RusPhrase rusPhrase)
    {
        RusPhrase = rusPhrase;
    }
    
    // ReSharper disable once UnusedMember.Local
    private Exercise()
    {
    }
}
