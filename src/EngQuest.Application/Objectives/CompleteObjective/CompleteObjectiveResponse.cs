using EngQuest.Application.Levels.GetLevel;

namespace EngQuest.Application.Objectives.CompleteObjective;

public class CompleteObjectiveResponse
{
    public required bool Success { get; init; }
    public required string CorrectAnswer { get; init; }
    public LevelResponse? Level { get; set; }
}
