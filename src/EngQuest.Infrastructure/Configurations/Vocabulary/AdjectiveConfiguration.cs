using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EngQuest.Domain.Shared;
using EngQuest.Domain.Vocabulary.Adjectives;

namespace EngQuest.Infrastructure.Configurations.Vocabulary;

public class AdjectiveConfiguration : IEntityTypeConfiguration<Adjective>
{
    public void Configure(EntityTypeBuilder<Adjective> builder)
    {
        builder.ToTable("adjectives");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Text)
            .HasMaxLength(50)
            .HasConversion(text => text.Value, value => new Text(value));
    }
}
