using DWShop.Application.Responses.Basket;
using DWShop.Shared.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWShop.Application.Features.Basket.Commands.Queries
{
	public class GetBasketQuery : IRequest<IResult<IEnumerable<BasketResponse>>>
	{

	}
}
