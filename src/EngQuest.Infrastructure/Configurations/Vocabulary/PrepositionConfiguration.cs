using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EngQuest.Domain.Shared;
using EngQuest.Domain.Vocabulary.Prepositions;

namespace EngQuest.Infrastructure.Configurations.Vocabulary;

public class PrepositionConfiguration : IEntityTypeConfiguration<Preposition>
{
    public void Configure(EntityTypeBuilder<Preposition> builder)
    {
        builder.ToTable("prepositions");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Text)
            .HasMaxLength(50)
            .HasConversion(text => text.Value, value => new Text(value));
    }
}
