namespace MetriFit;

    public interface INutritionRepository : IBaseSettingRepository<NutritionInformation>
    {
        Task<List<NutritionInformation>?> GetNutritionInformationByUserId(Guid id);
    }

