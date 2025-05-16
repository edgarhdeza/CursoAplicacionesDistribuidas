using AutoMapper;
using DWShop.Application.Responses.Basket;
using DWShop.Infrastructure.Repositories;
using DWShop.Shared.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWShop.Application.Features.Basket.Commands.Queries
{
	internal class GetBasketQueryHandler : IRequestHandler<GetBasketQuery, IResult<IEnumerable<BasketResponse>>>
	{
		private readonly IMapper _mapper;
		private readonly IRepositoryAsync<Domain.Entities.Basket, int> _basketRepoAsync;

		public GetBasketQueryHandler(IMapper mapper, IRepositoryAsync<Domain.Entities.Basket, int> repositoryAsync)
		{ 
			_mapper = mapper;
			_basketRepoAsync = repositoryAsync;
		}

		public async Task<IResult<IEnumerable<BasketResponse>>> Handle(GetBasketQuery request, CancellationToken cancellationToken)
		{
			var baskets = await _basketRepoAsync.GetAllAsync();

			var catalogResponse = _mapper.Map<List<BasketResponse>>(baskets);

			return await Result<IEnumerable<BasketResponse>>.SuccessAsync(catalogResponse, "");
		}
	}
}
