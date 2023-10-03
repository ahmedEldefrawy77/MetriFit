using MetriFit.Controllers.BaseController;
using MetriFit.UnitOfWorks.UntiOfWork.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MetriFit;

[Route("api/[controller]")]
[ApiController]
public class UserMeasurmentsController : BaseNameCompindedSettingController<User>
{
    private readonly IUserMeasurmentUnitOfWork _measurmentUnitOfWork;
    private readonly ITotalCaloriesPerDayUnitOfWork     _totalCaloriesPerDayUnitOfWork;


    public UserMeasurmentsController(IUserMeasurmentUnitOfWork measurmentUnitOfWrok, 
        ITotalCaloriesPerDayUnitOfWork totalCaloriesPerDayUnitOfWork) 
        : base(measurmentUnitOfWrok)
    {
        _measurmentUnitOfWork = measurmentUnitOfWrok;
        _totalCaloriesPerDayUnitOfWork = totalCaloriesPerDayUnitOfWork;
    }

    [HttpPost]
    public async Task<IActionResult> Post()
    {
        Guid id = GetUserId();

        UserCalculatedMeasurments calculation = await _measurmentUnitOfWork.GetUserMeasurments(id);

        ResponseResult<UserCalculatedMeasurments> response = new(calculation);

        return Ok(response);

    }
    [HttpPut]
    public async Task<IActionResult> Put(UserMeasurmentsUpdate update)
    {
        Guid id = GetUserId();

        User? user = await _measurmentUnitOfWork.UpdateMeasurmentsData(update, id);

        MeasurmentsUpdate measurmentsUpdate = new MeasurmentsUpdate();

        measurmentsUpdate.Weight = user.Weight;
        measurmentsUpdate.Height = user.Height;
        measurmentsUpdate.WaistCircumference = user.WaistCircumference;
        measurmentsUpdate.NeckCircumference = user.NeckCircumference;
        measurmentsUpdate.Name = user.FirstName;

        if(user.HipCircumference != null)
            measurmentsUpdate.HipCircumference = user.HipCircumference;

        ResponseResult<MeasurmentsUpdate> response = new(measurmentsUpdate);

        return Ok(response);
    }
    [HttpPost, Route("TotalCaloriesPerDay")]
    public async Task<IActionResult> CaloriesPerDay(DateTime date)
    {
        Guid id = GetUserId();

        TotalCaloriesPerDay? totalCal = new TotalCaloriesPerDay();

        totalCal = await _totalCaloriesPerDayUnitOfWork.GetTotalCaloriesPerDay(date, id);

        ResponseResult<TotalCaloriesPerDay> response = new(totalCal);

        return Ok(response);
    }
 }
