using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EngQuest.Domain.Shared;
using EngQuest.Domain.Vocabulary.Compounds;

namespace EngQuest.Infrastructure.Configurations.Vocabulary;

public class CompoundConfiguration : IEntityTypeConfiguration<Compound>
{
    public void Configure(EntityTypeBuilder<Compound> builder)
    {
        builder.ToTable("compounds");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Text)
            .HasMaxLength(50)
            .HasConversion(text => text.Value, value => new Text(value));

        builder.Property(c => c.Type);
    }
}
