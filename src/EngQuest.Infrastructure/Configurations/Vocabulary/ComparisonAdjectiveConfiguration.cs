using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EngQuest.Domain.Shared;
using EngQuest.Domain.Vocabulary.ComparisonAdjectives;

namespace EngQuest.Infrastructure.Configurations.Vocabulary;

public class ComparisonAdjectiveConfiguration : IEntityTypeConfiguration<ComparisonAdjective>
{
    public void Configure(EntityTypeBuilder<ComparisonAdjective> builder)
    {
        builder.ToTable("comparison_adjectives");

        builder.HasKey(ca => ca.Id);

        builder.Property(ca => ca.Text)
            .HasMaxLength(50)
            .HasConversion(text => text.Value, value => new Text(value));

        builder.Property(ca => ca.ComparativeForm)
            .HasMaxLength(50)
            .HasConversion(comparativeForm => comparativeForm.Value, value => new ComparativeForm(value));

        builder.Property(ca => ca.SuperlativeForm)
            .HasMaxLength(50)
            .HasConversion(superlativeForm => superlativeForm.Value, value => new SuperlativeForm(value));
    }
}
