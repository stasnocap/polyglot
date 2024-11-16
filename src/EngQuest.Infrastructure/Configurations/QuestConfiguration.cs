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
        
        builder
            .HasMany(x => x.Objectives)
            .WithOne()
            .HasForeignKey(x => x.QuestId);

        builder
            .Navigation(x => x.Objectives)
            .AutoInclude();
        
        builder.OwnsMany(l => l.Scores, scores =>
        {
            scores.ToTable("scores");

            scores.WithOwner().HasForeignKey("QuestId");

            scores.HasKey(x => x.Id);

            scores.Property(x => x.UserId);
            
            scores.OwnsOne(x => x.Rating);
        });
    }
}
