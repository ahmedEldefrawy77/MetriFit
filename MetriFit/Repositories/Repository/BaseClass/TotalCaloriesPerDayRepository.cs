namespace MetriFit;

public class TotalCaloriesPerDayRepository : BaseRepository<TotalCaloriesPerDay>, ITotalCaloriesPerDayRepository
{
    public TotalCaloriesPerDayRepository(ApplicationDbContext context) : base(context)
    {

    }
}
