using DWShop.Application.Responses.Catalog;
using DWShop.Shared.Wrapper;
using MediatR;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWShop.Application.Features.Catalog.Queries
{
	public class GetCatalogQuery : IRequest<IResult<IEnumerable<CatalogResponse>>>
	{

	}
}
