namespace EngQuest.Domain.Shared;

public static class Letters
{
    public static readonly IReadOnlyList<char> Consonants =
    [
        'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm',
        'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'z'
    ];
    
    public static readonly IReadOnlyList<char> Vowels =
    [
        'a', 'e', 'i', 'o', 'u', 'y'
    ];
}
