using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Polyglot.Domain.Shared;
using Polyglot.Domain.Vocabulary.Pronouns;

namespace Polyglot.Infrastructure.Configurations.Vocabulary;

public class PronounConfiguration : IEntityTypeConfiguration<Pronoun>
{
    public void Configure(EntityTypeBuilder<Pronoun> builder)
    {
        builder.ToTable("pronouns");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Text)
            .HasConversion(text => text.Value, value => new Text(value));

        builder.Property(p => p.Type);
    }
}
