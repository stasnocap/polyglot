using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Polyglot.Domain.Shared;
using Polyglot.Domain.Vocabulary.Languages;

namespace Polyglot.Infrastructure.Configurations.Vocabulary;

public class LanguageConfiguration : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.ToTable("languages");

        builder.HasKey(l => l.Id);

        builder.Property(l => l.Text)
            .HasMaxLength(50)
            .HasConversion(text => text.Value, value => new Text(value));
    }
}
