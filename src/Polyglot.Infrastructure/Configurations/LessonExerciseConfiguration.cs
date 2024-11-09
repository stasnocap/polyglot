using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Polyglot.Domain.Lessons;

namespace Polyglot.Infrastructure.Configurations;

public class LessonExerciseConfiguration : IEntityTypeConfiguration<LessonExercise>
{
    public void Configure(EntityTypeBuilder<LessonExercise> builder)
    {
        builder.ToTable("lesson_exercises");

        builder
            .Navigation(x => x.Exercise)
            .AutoInclude();
        
        builder.HasKey(x => new { x.LessonId, x.ExerciseId });
    }
}
