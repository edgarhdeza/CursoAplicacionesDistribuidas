using DWShop.Shared.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWShop.Application.Features.Category.Commands.Create
{
	public class CreateCategoryCommand : IRequest<IResult<int>>
	{
		public string Name { get; set; }
	}
}
