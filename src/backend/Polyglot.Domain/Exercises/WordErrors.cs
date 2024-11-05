using Polyglot.Domain.Abstractions;

namespace Polyglot.Domain.Exercises;

public static class WordErrors
{
    public static readonly Error NegativeNumber = new("Word.NegativeNumber", "Word number can't be negative or zero.");
    public static readonly Error EmptyText = new("Word.EmptyText", "Word text can't be empty.");
}
