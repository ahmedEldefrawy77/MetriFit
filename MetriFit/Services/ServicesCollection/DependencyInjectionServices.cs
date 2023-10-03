
using FluentValidation;
using Health_and_Nutritio;
using MetriFit.Middlware;
using MetriFit.Services.Goals;
using MetriFit.Services.MealLogCaloriesServices;
using MetriFit.UnitOfWorks.UntiOfWork.Class;
using MetriFit.UnitOfWorks.UntiOfWork.Interface;
using MetriFit.Validation;

namespace MetriFit;
public static class DependencyInjectionServices
{
   public static void AddDependencyInjectionService(this IServiceCollection services)
   {
        //BaseRepository Registeration
        services.AddSingleton(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddSingleton(typeof(IBaseSettingRepository<>), typeof(BaseSettingRepository<>));
        services.AddSingleton(typeof(INameCompinedBaseSettingRepository<>), typeof(NameCompinedBaseSettingRepository<>));
        //BaseUnitOfWork Registeration
        services.AddSingleton(typeof(IBaseUnitOfWorks<>), typeof(BaseUnitOfWork<>));
        services.AddSingleton(typeof(IBaseSettingUnitOfWork<>), typeof(BaseSettingUnitOfWork<>));
        services.AddSingleton(typeof(INameCompinedSettingUnitOfWork<>), typeof(NameCompinedBaseSettingUnitOfWork<>));

        services.AddSingleton<IJwtProvider, JwtProvider>();

        services.AddSingleton<RefreshTokenValidator>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ISupportAgentRepository, SupportAgentRepository>();
        services.AddScoped<INutritionRepository, NutritionRepository>();
        services.AddScoped<IMealLogRepository, MealLogRepository>();
        services.AddScoped<IGoalRepository, GoalRepository>();
        services.AddScoped<IExerciseRepository, ExerciseRepository>();
        services.AddScoped<ITotalCaloriesPerDayRepository, TotalCaloriesPerDayRepository>();
        //services.AddScoped<ITotalCaloriesPerDayRepository, TotalCaloriesPerDayRepository>();

        services.AddScoped<IAuthUserUnitOfWork, AuthUserUnitOfWork>();
        services.AddScoped<IExerciseUnitOfWork, ExerciseUnitOfWork>();
        services.AddScoped<IGoalUnitOfWork, GoalUnitOfWork>();
        services.AddScoped<IMealLogUnitOfWork, MealLogUnitOfWork>();
        //services.AddScoped<ITotalCalPerDayUnitOfWork, TotalCalPerDay>();
        services.AddScoped<ITotalCaloriesPerDayUnitOfWork, TotalCaloriesPerDayUnitOfWork>();
        services.AddScoped<IUserMeasurmentUnitOfWork, UserMeasurmentUnitOfWork>();


        services.AddScoped<IUserGenderFactory, MaleBodyMeasurment>();
        services.AddScoped<IUserGenderFactory, FemaleBodyMeasurment>();
        services.AddScoped<IMealLogTypeFactory, MealLogTypeFacotry>();
        services.AddScoped<IMealLogCaloriesMeausrments, MealLogCaloriesMeasurments>();


        services.AddScoped<IActivityLevel, ActivityLevel>();
        services.AddScoped<IGoalTypeFactory, GainWeightGoal>();
        services.AddScoped<IGoalTypeFactory, LossWeightGoal>();


        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

        services.AddTransient<IValidator<User>, CreatUserValidator>();

        services.AddTransient<GlobalErrorHandlingMiddleware>();
        services.AddTransient<DbTransactionHandlerMiddleware>();
    }
}

