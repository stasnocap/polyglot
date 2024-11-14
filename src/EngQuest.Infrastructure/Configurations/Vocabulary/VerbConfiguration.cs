using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EngQuest.Domain.Shared;
using EngQuest.Domain.Vocabulary.Verbs;

namespace EngQuest.Infrastructure.Configurations.Vocabulary;

public class VerbConfiguration : IEntityTypeConfiguration<Verb>
{
    public void Configure(EntityTypeBuilder<Verb> builder)
    {
        builder.ToTable("verbs");

        builder.HasKey(pv => pv.Id);

        builder.Property(pv => pv.Text)
            .HasMaxLength(50)
            .HasConversion(text => text.Value, value => new Text(value));

        builder.Property(pv => pv.PastForm)
            .HasMaxLength(50)
            .HasConversion(pastForm => pastForm.Value, value => new PastForm(value));

        builder.Property(pv => pv.PastParticipleForm)
            .HasMaxLength(50)
            .HasConversion(pastParticipleForm => pastParticipleForm.Value, value => new PastParticipleForm(value));

        builder.Property(pv => pv.PresentParticipleForm)
            .HasMaxLength(50)
            .HasConversion(presentParticipleForm => presentParticipleForm.Value, value => new PresentParticipleForm(value));

        builder.Property(pv => pv.ThirdPersonForm)
            .HasMaxLength(50)
            .HasConversion(thirdPersonForm => thirdPersonForm.Value, value => new ThirdPersonForm(value));

        builder.Property(pv => pv.IsIrregularVerb)
            .HasConversion(isIrregularVerb => isIrregularVerb.Value, value => new IsIrregularVerb(value));
    }
}
