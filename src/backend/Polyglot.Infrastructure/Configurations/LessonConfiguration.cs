using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Polyglot.Domain.Lessons;
using Polyglot.Domain.Lessons.Exercises;

namespace Polyglot.Infrastructure.Configurations;

public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.ToTable("lessons");
        
        builder.HasKey(l => l.Id);

        builder.Property(l => l.Name)
            .HasMaxLength(400)
            .HasConversion(name => name.Value, value => new LessonName(value));
        
        builder
            .HasMany(x => x.Exercises)
            .WithOne()
            .HasForeignKey(x => x.LessonId);

        builder
            .Navigation(x => x.Exercises)
            .AutoInclude();
        
        builder.OwnsMany(l => l.Scores, scores =>
        {
            scores.ToTable("scores");

            scores.WithOwner().HasForeignKey("LessonId");

            scores.HasKey(x => x.Id);

            scores.Property(x => x.UserId);
            
            scores.OwnsOne(x => x.Rating);
        });
    }
}
