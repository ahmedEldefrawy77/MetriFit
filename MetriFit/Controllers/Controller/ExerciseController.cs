using MetriFit.Controllers.BaseController;
using MetriFit.UnitOfWorks.UntiOfWork.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetriFit.Controllers.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : BaseSettingController<Exercise>
    {
        private readonly IExerciseUnitOfWork _unitOfWork;

        public ExerciseController(IExerciseUnitOfWork unitOfWork) : base(unitOfWork) => _unitOfWork = unitOfWork;

        [HttpGet , Route("ExerciseByDate")]
        public async Task<IActionResult> GetExerciseByDate(DateTime date)
        {
            Guid id= GetUserId();

            List<Exercise>? Exercises = await _unitOfWork.GetExercisesWithDate(date, id);

            ResponseResult<List<Exercise>?> reponse = new(Exercises);
            
            return Ok(reponse);

        }
        [HttpGet]
        public async Task<IActionResult> GetExercises()
        {
            Guid id = GetUserId();

            List<Exercise>? Exercises = await _unitOfWork.GetAllExercises( id);

            ResponseResult<List<Exercise>?> reponse = new(Exercises);

            return Ok(reponse);

        }
        [HttpPost]
        public async Task<IActionResult> Creat(Exercise ex)
        {
            Guid UserId = GetUserId();
            Exercise exercise = await _unitOfWork.CreatExercise(ex, UserId);

            ResponseResult<Exercise> response = new(exercise);
            return Ok(response);
        }

        [HttpDelete, Authorize]
        public async Task<IActionResult> Delete(Exercise ex)
        {
            await _unitOfWork.DeleteExercise(ex);

            ResponseResult response = new($"{nameof(ex)}Deleted");
            return Ok(response);
        }
    }
}
