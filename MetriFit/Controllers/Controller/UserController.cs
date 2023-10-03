using MetriFit.Controllers.BaseController;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetriFit.Controllers.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseNameCompindedSettingController<User>
    {
        private readonly IAuthUserUnitOfWork _userUnitOfWork;
        public UserController(IAuthUserUnitOfWork userUnitOfWork) : base(userUnitOfWork) => _userUnitOfWork = userUnitOfWork;

        [HttpGet, Authorize]
        public async Task<IActionResult> Get()
        {
            Guid id = GetUserId();

            User? user = await _userUnitOfWork.GetUserById(id);

            ResponseResult<User> response = new(user);

            return Ok(response);
        }
        [HttpPut, Authorize]
        public async Task<IActionResult> Update([FromForm] UserRequest user)
        {
            Guid id = GetUserId();

            await _userUnitOfWork.Update(user, id);

            ResponseResult response = new("Update Success");

            return Ok(response);
        }
        [HttpPut, Route("updatepassword"), Authorize]
        public async Task<IActionResult> Put(PasswordRecord requestUser)
        {
            Guid id = GetUserId();

            Token token = await _userUnitOfWork.UpdatePassword(
                requestUser, id);

            ResponseResult<Token> response = new(token);

            SetCookie("AccessToken",
            token.AccessToken,
            token.AccessTokneExDate);
            SetCookie("RefreshToken",
                token.RefreshToken,
                token.RefreshTokenExDate);

            return Ok(response);
        }
        [HttpDelete, Authorize]
        public async Task<IActionResult> Delete()
        {
            Guid userId = GetUserId();

            Response.Cookies.Delete("AccessToken");
            Response.Cookies.Delete("RefreshToken");

            return await Remove(userId);
        }
    }
}
