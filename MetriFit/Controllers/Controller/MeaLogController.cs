using MetriFit.Controllers.BaseController;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetriFit.Controllers.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealLogController : BaseSettingController<MealLog>

    {
        private readonly IMealLogUnitOfWork _unitOfWork;
        public MealLogController(IMealLogUnitOfWork unitOfWork) : base(unitOfWork) =>_unitOfWork = unitOfWork;

        [HttpPost]
        public async Task<IActionResult> CaloriesPerMeal(MealLog meallog)
        {
            Guid id = GetUserId();
            CaloriesConsumedPerMeal caloriesPerMeal = await _unitOfWork.CalculatTotalCaloriesConsumedPerMeal(meallog, id);

            ResponseResult<CaloriesConsumedPerMeal> response = new(caloriesPerMeal);

            return Ok(response);
        }
    }
}
