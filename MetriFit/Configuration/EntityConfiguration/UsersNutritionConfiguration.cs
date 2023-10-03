namespace MetriFit;
    public class UsersNutritionConfiguration: IEntityTypeConfiguration<UsersNutritions>
    {
        public void Configure(EntityTypeBuilder<UsersNutritions> builder)
        {
            builder
                .HasKey(e => new { e.UserId, e.NutritionInfortmationId});

            builder
                .HasOne(e => e.Users)
                .WithMany(e => e.UsersNutritions)
                .HasForeignKey(e => e.UserId);
            builder
                .HasOne(e => e.NutritionInformation)
                .WithMany(e => e.UserNutritions)
                .HasForeignKey(e => e.NutritionInfortmationId);
        }
    }

