using MetriFit.Controllers.BaseController;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetriFit.Controllers.AuthController
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogoutController : BaseEntityController<User>
    {
        private readonly IAuthUserUnitOfWork _userUnitOfWork;

        public LogoutController(IAuthUserUnitOfWork userUnitOfWork) : base(userUnitOfWork) =>
            _userUnitOfWork = userUnitOfWork;

        [HttpPost]
        public async Task<IActionResult> Logout(Token? token)
        {
           string refreshToken = HttpContext.Request.Cookies["RefreshToken"] ?? string.Empty;

           if(token != null && token.RefreshToken !=null)
                refreshToken = token.RefreshToken;


          await _userUnitOfWork.Logout(refreshToken);

          ResponseResult response = new("Logout success");

           return Ok();
        }
    }
}
