using EngQuest.Application.Levels.GetLevel;
using EngQuest.Domain.Levels;
using EngQuest.Domain.Objectives;

namespace EngQuest.Application.Objectives.CompleteObjective;

public class CompleteObjectiveResponse
{
    public CompleteObjectiveResult CompleteObjectiveResult { get; init; }
    public GainExperienceResult? GainExperienceResult { get; set; }
    public LevelResponse? Level { get; set; }
}
