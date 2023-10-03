namespace MetriFit;
    public class NutritionInformationConfiguration : BaseSettingsConfiguration<NutritionInformation>
    {
        public override void Configure(EntityTypeBuilder<NutritionInformation> builder)
        {
            base.Configure(builder);

            builder
                .Property(x => x.Calories)
                .IsRequired();
            builder
                .Property(x => x.Protien)
                .IsRequired();
            builder
                .Property(e => e.Fat)
                .IsRequired();
            builder
                .Property(e => e.Carbonhydrate)
                .IsRequired();
        }
    }

