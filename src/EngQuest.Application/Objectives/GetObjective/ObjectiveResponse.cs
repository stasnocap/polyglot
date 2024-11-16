namespace EngQuest.Application.Objectives.GetObjective;

public sealed class ObjectiveResponse
{
    public required int ObjectiveId { get; init; }
    
    public required int QuestId { get; init; }
    
    public required string RusPhrase { get; init; }
    
    public required string[][] WordGroups { get; init; }
    
    public int? RatingCorrectNumber { get; init; }
    
    public int? RatingWrongNumber { get; init; }
    
    public float? RatingRate { get; init; }
}
