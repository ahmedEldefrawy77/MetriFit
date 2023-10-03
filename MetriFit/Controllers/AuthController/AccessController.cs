using MetriFit.Controllers.BaseController;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetriFit.Controllers.AuthController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessController : BaseEntityController<User>
    {
        private readonly IAuthUserUnitOfWork _userUnitOfWork;

        public AccessController(IAuthUserUnitOfWork userUnitOfWork) : base(userUnitOfWork) =>
            _userUnitOfWork = userUnitOfWork;

        [HttpPost]
        public async Task<IActionResult> AccessToken(Token token)
        {
          string oldToken = HttpContext.Request.Cookies["RefreshToken"] ?? string.Empty;

            if(token != null && token.RefreshToken != null)
                oldToken = token.RefreshToken;

           Token newToken =  await _userUnitOfWork.Refresh(oldToken);


            ResponseResult<Token> response = new(newToken);

            SetCookie("AccessToken",
                       newToken.AccessToken,
                       newToken.AccessTokneExDate);
            SetCookie("RefreshToken",
                newToken.RefreshToken,
                newToken.RefreshTokenExDate);

            return Ok(response);
        }
    }
    
}
