using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EngQuest.Domain.Shared;
using EngQuest.Domain.Vocabulary.QuestionWords;

namespace EngQuest.Infrastructure.Configurations.Vocabulary;

public class QuestionWordConfiguration : IEntityTypeConfiguration<QuestionWord>
{
    public void Configure(EntityTypeBuilder<QuestionWord> builder)
    {
        builder.ToTable("question_words");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Text)
            .HasMaxLength(50)
            .HasConversion(text => text.Value, value => new Text(value));
    }
}
