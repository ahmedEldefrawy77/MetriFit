namespace MetriFit;

public class MealLogConfiguration : BaseSettingsConfiguration<MealLog> 
{
    public override void Configure(EntityTypeBuilder<MealLog> builder)
    {
        base.Configure(builder);


        builder.Property(e=>e.MealLogType).IsRequired();

        builder.Property(e => e.Sugar).IsRequired();

        builder.Property(x => x.ProtienConsumed).IsRequired();

        builder.Property(x => x.CarbonhydrateConsumed).IsRequired();

        builder.Property(x => x.FatConsumed).IsRequired();

        builder.Property(x => x.RepastGrams).IsRequired();

        builder.Property(y => y.Date).HasDefaultValue(DateTime.Now.Date).ValueGeneratedOnAdd();

        builder.HasOne(e=> e.User).WithMany(m=> m.MealLog).HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.CaloriesConsumedPerMeal).WithOne(e => e.Meal).HasForeignKey<MealLog>(e => e.CaloriesConsumedPerMealId);

    }
}
