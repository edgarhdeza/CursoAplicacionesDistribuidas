using DWShop.Application.Responses.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWShop.Web.Infrastructure.Services
{
	public class BasketService
	{
		public async Task<BasketResponse> CalcularPrecio()
		{
			var random = new Random();

			return new BasketResponse
			{
				TotalPrice = random.Next(0, 100)
			};
		}
	}
}
