using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EngQuest.Domain.Lessons;
using EngQuest.Domain.Lessons.Exercises;
using EngQuest.Domain.Shared;

namespace EngQuest.Infrastructure.Configurations;

public class ExerciseConfiguration: IEntityTypeConfiguration<Exercise>
{
    public void Configure(EntityTypeBuilder<Exercise> builder)
    {
        builder.ToTable("exercises");

        builder.HasMany<LessonExercise>()
            .WithOne(x => x.Exercise)
            .HasForeignKey(x => x.ExerciseId);

        builder.HasKey(x => x.Id);

        builder.Property(s => s.RusPhrase)
            .HasMaxLength(400)
            .HasConversion(rusPhrase => rusPhrase.Value, value => new RusPhrase(value));

        builder.OwnsMany(e => e.Words, words =>
        {
            words.ToTable("words");

            words.WithOwner()
                .HasForeignKey("ExerciseId");

            words.HasKey(x => x.Id);

            words.Property(x => x.Number)
                .HasConversion(number => number.Value, value => new WordNumber(value));

            words.Property(x => x.Text)
                .HasMaxLength(50)
                .HasConversion(text => text.Value, value => new Text(value));

            words.Property(x => x.Type);
        });
    }
}
