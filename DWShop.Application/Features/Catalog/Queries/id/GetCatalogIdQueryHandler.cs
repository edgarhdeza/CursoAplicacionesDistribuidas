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

namespace DWShop.Application.Features.Catalog.Queries.id
{
	public class GetCatalogIdQueryHandler : IRequestHandler<GetCatalogIdQuery, IResult<CatalogResponse>>
	{
		private readonly IMapper _mapper;
		private readonly IRepositoryAsync<Domain.Entities.Catalog, int> _catalogoRepoAsync;

		public GetCatalogIdQueryHandler(IMapper mapper, IRepositoryAsync<Domain.Entities.Catalog, int> repositoryAsync)
		{
			_mapper = mapper;
			_catalogoRepoAsync = repositoryAsync;
		}

		public async Task<IResult<CatalogResponse>> Handle(GetCatalogIdQuery request, CancellationToken cancellationToken)
		{
			var catalog = await _catalogoRepoAsync.GetByIdAsync(request.CatalogId);

			var catalogResponse = _mapper.Map<CatalogResponse>(catalog);

			return await Result<CatalogResponse>.SuccessAsync(catalogResponse, "");
		}
	}
}
