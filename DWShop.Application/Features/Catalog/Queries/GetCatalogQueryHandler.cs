using AutoMapper;
using DWShop.Application.Responses.Catalog;
using DWShop.Infrastructure.Repositories;
using DWShop.Shared.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWShop.Application.Features.Catalog.Queries
{
	public class GetCatalogQueryHandler : IRequestHandler<GetCatalogQuery, IResult<IEnumerable<CatalogResponse>>>
	{
		private readonly IMapper _mapper;
		private readonly IRepositoryAsync<Domain.Entities.Catalog, int> _catalogoRepoAsync;

		public GetCatalogQueryHandler(IMapper mapper, IRepositoryAsync<Domain.Entities.Catalog, int> repositoryAsync)
		{ 
			_mapper = mapper;
			_catalogoRepoAsync = repositoryAsync;
		}

		public async Task<IResult<IEnumerable<CatalogResponse>>> Handle(GetCatalogQuery request, CancellationToken cancellationToken)
		{
			var catalogs = await _catalogoRepoAsync.GetAllAsync();

			var catalogResponse = _mapper.Map<List<CatalogResponse>>(catalogs);

			return await Result<IEnumerable<CatalogResponse>>.SuccessAsync(catalogResponse, "");
		}
	}
}
