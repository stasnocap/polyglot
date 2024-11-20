using EngQuest.Domain.Abstractions;

namespace EngQuest.Domain.Quests;

public sealed class Quest : Entity
{
    public QuestName Name { get; }

    public Quest(QuestName name)
    {
        Name = name;
    }

    // ReSharper disable once UnusedMember.Local
    private Quest()
    {
    }
}
