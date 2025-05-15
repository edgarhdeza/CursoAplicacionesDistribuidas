using AutoMapper;
using DWShop.Infrastructure.Repositories;
using DWShop.Shared.Wrapper;
using MediatR;

namespace DWShop.Application.Features.Catalog.Commands.Delete
{
	public class DeleteCatalogCommandHandler : IRequestHandler<DeleteCatalogCommand, IResult>
	{
		private readonly IMapper mapper;
		private readonly IRepositoryAsync<Domain.Entities.Catalog, int> repositoryAsync;

		public DeleteCatalogCommandHandler(IMapper mapper, IRepositoryAsync<Domain.Entities.Catalog, int> repositoryAsync) 
		{
			this.mapper = mapper;
			this.repositoryAsync = repositoryAsync;
		}

		public async Task<IResult> Handle(DeleteCatalogCommand request, CancellationToken cancellationToken)
		{
			var catalog = await repositoryAsync.GetByIdAsync(request.CatalogId);

			if (catalog == null)
			{
				throw new Exception($"No se encontro el producto con el ID {request.CatalogId}");
			}

			await repositoryAsync.DeleteAsync(catalog);

			await repositoryAsync.SaveChangesAsync();

			return Result.Success();
		}
	}
}
