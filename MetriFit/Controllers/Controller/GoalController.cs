using MetriFit.Controllers.BaseController;
using MetriFit.UnitOfWorks.UntiOfWork.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace MetriFit.Controllers.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalController : BaseEntityController<Goal>
    {
        private readonly IGoalUnitOfWork _unitOfWork;
  
        public GoalController(IGoalUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
           
        }


        [HttpPost]
        public async Task<IActionResult> SetGoal(string GoalType)
        {
            Guid id = GetUserId();

            Goal g = await _unitOfWork.SetGoal(GoalType, id);

            ResponseResult<Goal> response = new(g);

            return Ok(response);

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGoal()
        {
            Guid id = GetUserId();

            await _unitOfWork.DeleteGoal(id);

            ResponseResult<string> reponse = new("Goal has been Deleted Successfully: now you Can Set another Goal");

            return Ok(reponse);
        }

    }
}
