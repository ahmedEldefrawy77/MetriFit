using MetriFit;

namespace MetriFit;

public class GoalConfiguration : BaseConfiguration<Goal>
{
    public override void Configure(EntityTypeBuilder<Goal> builder)
    {
        base.Configure(builder);


        builder.HasOne(e => e.User).WithOne(e => e.Goal).HasForeignKey<Goal>(e => e.UserId).OnDelete(DeleteBehavior.Cascade);

        builder.Property(e => e.DateStartedAt).HasDefaultValue(DateTime.UtcNow).ValueGeneratedOnAdd();

        builder.Property(e => e.DateExAt).HasDefaultValue(DateTime.UtcNow.AddDays(14)).ValueGeneratedOnAdd();

    }
}

