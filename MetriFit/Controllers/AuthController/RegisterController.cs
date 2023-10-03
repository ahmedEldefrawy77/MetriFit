using MetriFit.Controllers.BaseController;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetriFit.Controllers.AuthController
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : BaseEntityController<User>
    {
        private readonly IAuthUserUnitOfWork _userUnitOfWork;

        public RegisterController(IAuthUserUnitOfWork userUnitOfWork) : base(userUnitOfWork) =>
            _userUnitOfWork = userUnitOfWork;

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            Token token = await _userUnitOfWork.Register(user);

            ResponseResult<Token> response = new(token);

            SetCookie("AccessToken",
                       token.AccessToken,
                       token.AccessTokneExDate);
            SetCookie("RefreshToken",
                token.RefreshToken,
                token.RefreshTokenExDate);

            return Ok(response);
        }
    }
}
