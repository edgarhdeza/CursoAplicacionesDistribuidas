using DWShop.Application.Features.Basket.Commands.Create;
using DWShop.Application.Responses.Basket;
using DWShop.Client.Infrastructure.Extensions;
using DWShop.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DWShop.Client.Infrastructure.Managers.Baskets
{
	public class CreateBasketManager : ICreateBasketManager
	{
		private readonly HttpClient httpClient;

		public CreateBasketManager(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}

		public async Task<IResult<int>> CreateBasket(CreateBasketCommand command)
		{
			var response = await httpClient.PostAsJsonAsync(Routes.Baskets.BasketEndpoints.CreateBasket, command);
			var result = await response.ToResult<int>();

			return result;
		}
	}
}
