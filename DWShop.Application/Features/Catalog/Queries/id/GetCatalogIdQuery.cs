using DWShop.Application.Responses.Catalog;
using DWShop.Shared.Wrapper;
using MediatR;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWShop.Application.Features.Catalog.Queries.id
{
	public class GetCatalogIdQuery : IRequest<IResult<CatalogResponse>>
	{
		public int CatalogId { get; set; }
	}
}
