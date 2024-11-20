using EngQuest.Domain.Abstractions;

namespace EngQuest.Domain.Objectives;

public static class ObjectiveErrors
{
    public static readonly Error NotFound = new(
        "Objective.NotFound",
        "Objective was not found");
}
