using AutoMapper;
using DWShop.Infrastructure.Repositories;
using DWShop.Shared.Wrapper;
using MediatR;

namespace DWShop.Application.Features.Catalog.Commands.Create
{
	public class CreateCatalogCommandHandler : IRequestHandler<CreateCatalogCommand, IResult<int>>
	{
		private readonly IMapper mapper;
		private readonly IRepositoryAsync<Domain.Entities.Catalog, int> repositoryAsync;
		private readonly IRepositoryAsync<Domain.Entities.Category, int> categoryRepoAsync;

		public CreateCatalogCommandHandler(IMapper mapper, IRepositoryAsync<Domain.Entities.Catalog, int> repositoryAsync, IRepositoryAsync<Domain.Entities.Category, int> categoryRepoAsync)
		{ 
			this.mapper = mapper;
			this.repositoryAsync = repositoryAsync;
			this.categoryRepoAsync = categoryRepoAsync;
		}

		public async Task<IResult<int>> Handle(CreateCatalogCommand request, CancellationToken cancellationToken)
		{
			var existCategory = await categoryRepoAsync.GetByIdAsync(request.CategoryId);

			if (existCategory == null)
			{
				return Result<int>.Fail("No existe la categoria");
			}


			var catalogDb = await repositoryAsync.GetPagedAsync(1, 1, x => x.Name == request.Name, default);

			if (catalogDb.Any())
			{
				throw new Exception($"El producto {request.Name} ya se encuentra en la base de datos");
			}

			var catalog = mapper.Map<Domain.Entities.Catalog>(request);

			await repositoryAsync.AddAsync(catalog);

			await repositoryAsync.SaveChangesAsync();

			return await Result<int>.SuccessAsync(catalog.Id, "");
		}
	}
}
