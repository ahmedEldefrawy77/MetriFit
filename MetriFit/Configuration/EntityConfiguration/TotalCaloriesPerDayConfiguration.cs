using Microsoft.EntityFrameworkCore;

namespace MetriFit.Configuration.EntityConfiguration
{
    public class TotalCaloriesPerDayConfiguration : BaseConfiguration<TotalCaloriesPerDay>
    {
        public override void Configure(EntityTypeBuilder<TotalCaloriesPerDay> builder)
        {
            base.Configure(builder);

            builder.HasOne(e=> e.User).WithMany(e=>e.TotalCal).HasForeignKey(e=>e.UserId).OnDelete(DeleteBehavior.Cascade);
            
        }
    }
}
