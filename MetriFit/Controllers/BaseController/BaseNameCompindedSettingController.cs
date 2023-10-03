using Microsoft.AspNetCore.Mvc;

namespace MetriFit.Controllers.BaseController
{
    public class BaseNameCompindedSettingController<TEntity> : BaseEntityController<TEntity> where TEntity : BaseEntitySettingNameCompind
    {
        private readonly INameCompinedSettingUnitOfWork<TEntity> _baseSettingsUnitOfWork;
        public BaseNameCompindedSettingController(INameCompinedSettingUnitOfWork<TEntity> unitOfWork) : base(unitOfWork)
            => _baseSettingsUnitOfWork = unitOfWork;

        protected virtual async Task<IActionResult> Search([FromRoute] string searchText)
        {
            IEnumerable<TEntity?> entities = await _baseSettingsUnitOfWork.SearchByName(searchText, searchText);

            ResponseResult<IEnumerable<TEntity?>> response = new(entities);

            return Ok(response);
        }
    }
}
