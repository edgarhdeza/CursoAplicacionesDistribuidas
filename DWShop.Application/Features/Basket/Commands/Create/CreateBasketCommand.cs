using DWShop.Shared.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWShop.Application.Features.Basket.Commands.Create
{
	public class CreateBasketCommand : IRequest<IResult<int>>
	{
		public decimal TotalPrice { get; set; }
	}
}
