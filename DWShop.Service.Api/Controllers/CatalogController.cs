using DWShop.Application.Features.Catalog.Commands.Create;
using DWShop.Application.Features.Catalog.Commands.Delete;
using DWShop.Application.Features.Catalog.Queries;
using DWShop.Application.Features.Catalog.Queries.id;
using DWShop.Application.Responses.Catalog;
using DWShop.Shared.Wrapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DWShop.Service.Api.Controllers
{
	public class CatalogController : BaseApiController
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="createCatalogCommand"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<ActionResult<Result<int>>> CreateProduct([FromBody] CreateCatalogCommand createCatalogCommand) => Ok(await mediator.Send(createCatalogCommand));


		/// <summary>
		/// Borrra el registro con el ID dado de la tabla de Catalgo
		/// </summary>
		/// <param name="deleteCatalogCommand"></param>
		/// <returns></returns>
		[HttpDelete]
		public async Task<ActionResult<Result>> DeleteProduct([FromBody] DeleteCatalogCommand deleteCatalogCommand) => Ok(await mediator.Send(deleteCatalogCommand));

		/// <summary>
		/// Muestra todos los registros de catalogos
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<ActionResult<Result<IEnumerable<CatalogResponse>>>> GetAll() => Ok(await mediator.Send(new GetCatalogQuery()));

		[HttpGet("{id}")]
		public async Task<ActionResult<Result<CatalogResponse>>> GetCatalog(int id) => Ok(await mediator.Send(new GetCatalogIdQuery { CatalogId = id }));
 	}
}
