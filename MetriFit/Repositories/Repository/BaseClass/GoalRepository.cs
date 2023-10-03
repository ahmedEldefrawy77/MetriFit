namespace MetriFit;
public class GoalRepository : BaseRepository<Goal>, IGoalRepository
{
    public GoalRepository(ApplicationDbContext Context) : base(Context) { }

    public async Task DeleteGoalWithUserId(Guid id)
    {
        Goal? goal = await _dbSet.FirstOrDefaultAsync(x => x.UserId == id);

        if(goal == null)
            throw new ArgumentNullException(nameof(goal));

        await Delete(goal);

    }

}
