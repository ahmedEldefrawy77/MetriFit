using Microsoft.EntityFrameworkCore;

namespace MetriFit;

public class ExerciseConfiguration : BaseSettingsConfiguration<Exercise>
{
    public override void Configure(EntityTypeBuilder<Exercise> builder)
    {
        base.Configure(builder);

        builder.Property(e=> e.CaloriesBurned).IsRequired();

        builder.Property(e => e.DateCreatedAt).HasDefaultValue(DateTime.UtcNow).IsRequired();

        builder.HasOne(e => e.User).WithMany(e => e.Exercise).HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Cascade);
       
    }
}
