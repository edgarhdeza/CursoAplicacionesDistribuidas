using DWShop.Application.Features.Basket.Commands.Create;
using DWShop.Application.Features.Basket.Commands.Queries;
using DWShop.Application.Responses.Basket;
using DWShop.Shared.Wrapper;
using Microsoft.AspNetCore.Mvc;

namespace DWShop.Service.Api.Controllers
{
	public class BasketController : BaseApiController
	{
		[HttpGet]
		public async Task<ActionResult<IEnumerable<BasketResponse>>> GetAll() => Ok(await mediator.Send(new GetBasketQuery()));

		[HttpPost]
		public async Task<ActionResult<Result<int>>> CreateBasket([FromBody] CreateBasketCommand createBasketCommand) => Ok(await mediator.Send(createBasketCommand));
	}
}
