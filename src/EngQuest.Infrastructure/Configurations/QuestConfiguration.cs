using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EngQuest.Domain.Quests;

namespace EngQuest.Infrastructure.Configurations;

public class QuestConfiguration : IEntityTypeConfiguration<Quest>
{
    public void Configure(EntityTypeBuilder<Quest> builder)
    {
        builder.ToTable("quests");
        
        builder.HasKey(l => l.Id);

        builder.Property(l => l.Name)
            .HasMaxLength(400)
            .HasConversion(name => name.Value, value => new QuestName(value));
    }
}
