
namespace MetriFit;
    public class NutritionRepository : BaseSettingRepository<NutritionInformation>, INutritionRepository
    {
        public NutritionRepository(ApplicationDbContext context) : base(context){ }

        public async Task<List<NutritionInformation>?> GetNutritionInformationByUserId(Guid id)
        {
        List<NutritionInformation> Nutritions = new List<NutritionInformation>();
        Nutritions = await _dbSet.Where(e => e.UserId == id).ToListAsync();
        return Nutritions;
        }
    }

