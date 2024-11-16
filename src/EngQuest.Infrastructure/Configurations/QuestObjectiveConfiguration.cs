using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EngQuest.Domain.Quests;

namespace EngQuest.Infrastructure.Configurations;

public class QuestObjectiveConfiguration : IEntityTypeConfiguration<QuestObjective>
{
    public void Configure(EntityTypeBuilder<QuestObjective> builder)
    {
        builder.ToTable("quest_objectives");

        builder
            .Navigation(x => x.Objective)
            .AutoInclude();
        
        builder.HasKey(x => new { x.QuestId, x.ObjectiveId });
    }
}
