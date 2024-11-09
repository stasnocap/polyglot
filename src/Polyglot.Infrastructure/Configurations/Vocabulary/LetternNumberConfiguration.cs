using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Polyglot.Domain.Shared;
using Polyglot.Domain.Vocabulary.LetterNumbers;

namespace Polyglot.Infrastructure.Configurations.Vocabulary;

public class LetterNumberConfiguration : IEntityTypeConfiguration<LetterNumber>
{
    public void Configure(EntityTypeBuilder<LetterNumber> builder)
    {
        builder.ToTable("letter_numbers");

        builder.HasKey(ln => ln.Id);

        builder.Property(ln => ln.Text)
            .HasMaxLength(50)
            .HasConversion(text => text.Value, value => new Text(value));

        builder.Property(ln => ln.Number)
            .HasConversion(number => number.Value, value => new Number(value));
    }
}
