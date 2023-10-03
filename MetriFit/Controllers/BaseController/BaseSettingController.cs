using Microsoft.AspNetCore.Mvc;

namespace MetriFit.Controllers.BaseController
{
    public class BaseSettingController<TEntity> : BaseEntityController<TEntity> 
        where TEntity : BaseEntitySettings
    {
        private readonly IBaseSettingUnitOfWork<TEntity> _baseSettingsUnitOfWork;
        public BaseSettingController(IBaseSettingUnitOfWork<TEntity> unitOfWork) : base(unitOfWork)
            => _baseSettingsUnitOfWork = unitOfWork;

        protected virtual async Task<IActionResult> Search([FromRoute] string searchText)
        {
            IEnumerable<TEntity> entities = await _baseSettingsUnitOfWork.SearchByName(searchText);

            ResponseResult<IEnumerable<TEntity>> response = new(entities);

            return Ok(response);
        }
    }
}
