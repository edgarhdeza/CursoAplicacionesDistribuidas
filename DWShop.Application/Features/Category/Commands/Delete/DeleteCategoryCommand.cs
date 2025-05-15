using DWShop.Shared.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWShop.Application.Features.Category.Commands.Delete
{
	public class DeleteCategoryCommand : IRequest<IResult>
	{
		public int CategoryId { get; set; }
	}
}
