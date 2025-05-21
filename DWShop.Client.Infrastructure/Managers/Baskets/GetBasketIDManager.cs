using DWShop.Application.Features.Basket.Commands.Queries;
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
	public class GetBasketIDManager : IGetBasketIDManager
	{
		private readonly HttpClient httpClient;

		public GetBasketIDManager(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}

		public async Task<IResult<BasketResponse>> GetBasketById(GetBasketByIdQuery query)
		{
			var response = await httpClient.GetAsync(Routes.Baskets.BasketEndpoints.GetBasketById + "/" + query.Id);
			var result = await response.ToResult<BasketResponse>();

			return result;
		}
	}
}
