using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Polyglot.Domain.Shared;
using Polyglot.Domain.Vocabulary.ModalVerbs;

namespace Polyglot.Infrastructure.Configurations.Vocabulary;

public class ModalVerbConfiguration : IEntityTypeConfiguration<ModalVerb>
{
    public void Configure(EntityTypeBuilder<ModalVerb> builder)
    {
        builder.ToTable("modal_verbs");

        builder.HasKey(mv => mv.Id);

        builder.Property(mv => mv.Text)
            .HasMaxLength(50)
            .HasConversion(text => text.Value, value => new Text(value));

        builder.Property(mv => mv.FullNegativeForm)
            .HasMaxLength(50)
            .HasConversion(fullNegativeForm => fullNegativeForm.Value, value => new FullNegativeForm(value));

        builder.Property(mv => mv.ShortNegativeForm)
            .HasMaxLength(50)
            .HasConversion(shortNegativeForm => shortNegativeForm.Value, value => new ShortNegativeForm(value));
    }
}
