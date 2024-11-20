using EngQuest.Domain.Levels;
using EngQuest.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EngQuest.Infrastructure.Configurations;

public class LevelConfiguration : IEntityTypeConfiguration<Level>
{
    public void Configure(EntityTypeBuilder<Level> builder)
    {
        builder.ToTable("levels");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Value)
            .HasColumnName("level")
            .HasDefaultValue(1);
            
        builder.Property(x => x.Experience)
            .HasColumnName("level_xp");

        builder.HasOne<User>()
            .WithOne()
            .HasForeignKey<Level>(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
