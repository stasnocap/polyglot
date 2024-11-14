using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EngQuest.Domain.Shared;
using EngQuest.Domain.Vocabulary.Determiners;

namespace EngQuest.Infrastructure.Configurations.Vocabulary;

public class DeterminerConfiguration : IEntityTypeConfiguration<Determiner>
{
    public void Configure(EntityTypeBuilder<Determiner> builder)
    {
        builder.ToTable("determiners");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.Text)
            .HasMaxLength(50)
            .HasConversion(text => text.Value, value => new Text(value));
    }
}
