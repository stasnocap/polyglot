using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Polyglot.Domain.Lessons;
using Polyglot.Domain.Lessons.Exercises;
using Polyglot.Domain.Shared;

namespace Polyglot.Infrastructure.Configurations;

public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        ConfigureLesson(builder);
        ConfigureExercises(builder);
        ConfigureScores(builder);
    }

    private static void ConfigureExercises(EntityTypeBuilder<Lesson> builder)
    {
        builder.OwnsMany(l => l.Exercises, exercises =>
        {
            exercises.ToTable("exercises");

            exercises.WithOwner()
                .HasForeignKey("LessonId");

            exercises.HasKey(x => x.Id);

            exercises.Property(s => s.RusPhrase)
                .HasMaxLength(400)
                .HasConversion(rusPhrase => rusPhrase.Value, value => new RusPhrase(value));

            exercises.OwnsMany(e => e.Words, words =>
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
        });
    }

    private static void ConfigureScores(EntityTypeBuilder<Lesson> builder)
    {
        builder.OwnsMany(l => l.Scores, scores =>
        {
            scores.ToTable("scores");

            scores.WithOwner().HasForeignKey("LessonId");

            scores.HasKey(x => x.Id);

            scores.Property(x => x.UserId);
            
            scores.OwnsOne(x => x.Rating);
        });
    }

    private static void ConfigureLesson(EntityTypeBuilder<Lesson> builder)
    {
        builder.ToTable("lessons");
        
        builder.HasKey(l => l.Id);

        builder.Property(l => l.Name)
            .HasMaxLength(400)
            .HasConversion(name => name.Value, value => new LessonName(value));
    }
}
