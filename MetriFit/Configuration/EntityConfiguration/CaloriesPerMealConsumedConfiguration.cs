namespace MetriFit.Configuration.EntityConfiguration
{
    public class CaloriesPerMealConsumedConfiguration : BaseConfiguration<CaloriesConsumedPerMeal>
    {
        public override void Configure(EntityTypeBuilder<CaloriesConsumedPerMeal> builder)
        {
            base.Configure(builder);

            builder.HasOne(e => e.Meal).WithOne(e => e.CaloriesConsumedPerMeal).HasForeignKey<CaloriesConsumedPerMeal>(e => e.MealId).OnDelete(DeleteBehavior.Cascade);

            builder.Property(e=>e.Date).HasDefaultValue(DateTime.Now).ValueGeneratedOnAdd();
        }
    }
}
