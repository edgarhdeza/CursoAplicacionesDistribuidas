using DWShop.Application.Features.Basket.Commands.Queries;
using DWShop.Application.Responses.Basket;
using DWShop.Client.Infrastructure.Managers.Base;
using DWShop.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWShop.Client.Infrastructure.Managers.Baskets
{
	public interface IGetBasketIDManager : IManager
	{
		Task<IResult<BasketResponse>> GetBasketById(GetBasketByIdQuery query);

	}
}
