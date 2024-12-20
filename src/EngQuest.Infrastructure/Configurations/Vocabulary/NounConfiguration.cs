﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EngQuest.Domain.Shared;
using EngQuest.Domain.Vocabulary.Nouns;

namespace EngQuest.Infrastructure.Configurations.Vocabulary;

public class NounConfiguration : IEntityTypeConfiguration<Noun>
{
    public void Configure(EntityTypeBuilder<Noun> builder)
    {
        builder.ToTable("nouns");

        builder.HasKey(n => n.Id);

        builder.Property(n => n.Text)
            .HasMaxLength(50)
            .HasConversion(text => text.Value, value => new Text(value));

        builder.Property(n => n.PluralForm)
            .HasMaxLength(50)
            .HasConversion(pluralForm => pluralForm.Value, value => new PluralForm(value));

        builder.Property(n => n.Type);
    }
}
