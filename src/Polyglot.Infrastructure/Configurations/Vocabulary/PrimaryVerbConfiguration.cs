using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Polyglot.Domain.Shared;
using Polyglot.Domain.Vocabulary.PrimaryVerbs;
using Polyglot.Domain.Vocabulary.Verbs;

namespace Polyglot.Infrastructure.Configurations.Vocabulary;

public class PrimaryVerbConfiguration : IEntityTypeConfiguration<PrimaryVerb>
{
    public void Configure(EntityTypeBuilder<PrimaryVerb> builder)
    {
        ConfigurePrimaryVerbs(builder);
        ConfigureFullNegativeForms(builder);
        ConfigureShortNegativeForms(builder);
        ConfigureAdditionalForms(builder);
    }

    private static void ConfigureAdditionalForms(EntityTypeBuilder<PrimaryVerb> builder)
    {
        builder.OwnsMany(pv => pv.AdditionalForms, additionalForms =>
        {
            additionalForms.ToTable("additional_forms");

            additionalForms.WithOwner().HasForeignKey("PrimaryVerbId");

            additionalForms.HasKey("Id");

            additionalForms.Property(fnf => fnf.Value).HasColumnName("text");
        });
    }

    private static void ConfigureShortNegativeForms(EntityTypeBuilder<PrimaryVerb> builder)
    {
        builder.OwnsMany(pv => pv.ShortNegativeForms, shortNegativeForms =>
        {
            shortNegativeForms.ToTable("short_negative_forms");

            shortNegativeForms.WithOwner().HasForeignKey("PrimaryVerbId");

            shortNegativeForms.HasKey("Id");

            shortNegativeForms.Property(fnf => fnf.Value)
                .HasColumnName("text");
        });
    }

    private static void ConfigureFullNegativeForms(EntityTypeBuilder<PrimaryVerb> builder)
    {
        builder.OwnsMany(pv => pv.FullNegativeForms, fullNegativeForms =>
        {
            fullNegativeForms.ToTable("full_negative_forms");

            fullNegativeForms.WithOwner().HasForeignKey("PrimaryVerbId");

            fullNegativeForms.HasKey("Id");

            fullNegativeForms.Property(fnf => fnf.Value)
                .HasColumnName("text");
        });
    }

    private static void ConfigurePrimaryVerbs(EntityTypeBuilder<PrimaryVerb> builder)
    {
        builder.ToTable("primary_verbs");

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
    }
}
