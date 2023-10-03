using Microsoft.AspNetCore.Mvc;

namespace MetriFit.Controllers.BaseController
{
    public class BaseEntityController<TEntity> : ControllerBase where TEntity : BaseEntity
    {
        private readonly IBaseUnitOfWorks<TEntity> _unitOfWork;
        public BaseEntityController(IBaseUnitOfWorks<TEntity> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        protected virtual async Task<IActionResult> Create(TEntity entity)
        {
            await _unitOfWork.Creat(entity);

            ResponseResult<string> response = new($"{typeof(TEntity).Name} created");

            return Ok(response);
        }

       
        protected virtual async Task<IActionResult> Read(Guid id)
        {
            TEntity entity = await _unitOfWork.Read(id);

            ResponseResult<TEntity> response = new(entity);

            return Ok(response);
        }

        protected async virtual Task<IActionResult> Update(TEntity entity)
        {
            await _unitOfWork.Update(entity);

            ResponseResult<TEntity> response = new(entity);

            return Ok(response);
        }

        protected async virtual Task<IActionResult> Remove(Guid id)
        {
            await _unitOfWork.Delete(id);

            ResponseResult<string> response = new($"{typeof(TEntity).Name} Deleted");

            return Ok(response);
        }
        protected void SetCookie(string name, string? value, DateTime expireTime)
        {
            if (value != null)
                Response.Cookies.Append(name, value
                , new CookieOptions()
                {
                    HttpOnly = true,
                    Expires = expireTime
                });
        }
        protected Guid GetUserId()
        => new(User?.FindFirst("Id")?.Value??"null");
    }
}
  