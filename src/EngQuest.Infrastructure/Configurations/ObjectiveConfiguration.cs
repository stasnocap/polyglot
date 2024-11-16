using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EngQuest.Domain.Quests;
using EngQuest.Domain.Quests.Objectives;
using EngQuest.Domain.Shared;

namespace EngQuest.Infrastructure.Configurations;

public class ObjectiveConfiguration: IEntityTypeConfiguration<Objective>
{
    public void Configure(EntityTypeBuilder<Objective> builder)
    {
        builder.ToTable("objectives");

        builder.HasMany<QuestObjective>()
            .WithOne(x => x.Objective)
            .HasForeignKey(x => x.ObjectiveId);

        builder.HasKey(x => x.Id);

        builder.Property(s => s.RusPhrase)
            .HasMaxLength(400)
            .HasConversion(rusPhrase => rusPhrase.Value, value => new RusPhrase(value));

        builder.OwnsMany(e => e.Words, words =>
        {
            words.ToTable("words");

            words.WithOwner()
                .HasForeignKey("ObjectiveId");

            words.HasKey(x => x.Id);

            words.Property(x => x.Number)
                .HasConversion(number => number.Value, value => new WordNumber(value));

            words.Property(x => x.Text)
                .HasMaxLength(50)
                .HasConversion(text => text.Value, value => new Text(value));

            words.Property(x => x.Type);
        });
    }
}
