using EngQuest.Domain.Abstractions;

namespace EngQuest.Domain.Quests;

public static class QuestErrors
{
    public static readonly Error NotFound = new(
        "Quest.NotFound",
        "Quest was not found");
    
    public static readonly Error ObjectiveNotFound = new(
        "Quest.ObjectiveNotFound",
        "Objective was not found");
    
    public static readonly Error ObjectiveAlreadyExists = new(
        "Quest.ObjectiveAlreadyExists",
        "Such objective already exists");
    
    public static readonly Error ObjectiveWordsAreEmpty = new(
        "Quest.ObjectiveWordsAreEmpty",
        "Objective words can't be empty");
}
