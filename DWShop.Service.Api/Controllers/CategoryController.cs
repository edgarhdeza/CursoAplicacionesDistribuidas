using DWShop.Application.Features.Category.Commands.Create;
using DWShop.Application.Features.Category.Commands.Delete;
using DWShop.Shared.Wrapper;
using Microsoft.AspNetCore.Mvc;

namespace DWShop.Service.Api.Controllers
{
	public class CategoryController : BaseApiController
	{
		[HttpPost]
		public async Task<ActionResult<Result<int>>> CreateCategory([FromBody] CreateCategoryCommand createCategoryCommand)
			=> Ok(await mediator.Send(createCategoryCommand));

		[HttpDelete]
		public async Task<ActionResult<Result>> DeleteCategory([FromBody] DeleteCategoryCommand deleteCategoryCommand)
			=> Ok(await mediator.Send(deleteCategoryCommand));
	}
}
