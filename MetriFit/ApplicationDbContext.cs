using MetriFit.Configuration.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace MetriFit;

public class ApplicationDbContext : DbContext
{
	
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder
                       .ApplyConfiguration(new UserConfiguration())
                       .ApplyConfiguration(new RefreshTokenConfiguration())
                       .ApplyConfiguration(new UsersNutritionConfiguration())
                       .ApplyConfiguration(new CaloriesPerMealConsumedConfiguration())
                       .ApplyConfiguration(new SupportAgentConfiguration())
                       .ApplyConfiguration(new NutritionInformationConfiguration())
                       .ApplyConfiguration(new MealLogConfiguration())
                       .ApplyConfiguration(new GoalConfiguration())
                       .ApplyConfiguration(new ExerciseConfiguration());
                       
	    
}

