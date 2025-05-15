using DWShop.Infrastructure.Repositories;
using DWShop.Shared.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWShop.Application.Features.Category.Commands.Delete
{
	internal class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, IResult>
	{
		private readonly IRepositoryAsync<Domain.Entities.Category, int> categoryRepoAsync;
		private readonly IRepositoryAsync<Domain.Entities.Catalog, int> catalogRepoAsync;

		public DeleteCategoryCommandHandler(IRepositoryAsync<Domain.Entities.Category, int> categoryRepoAsync, IRepositoryAsync<Domain.Entities.Catalog, int> catalogRepoAsync)
		{ 
			this.categoryRepoAsync = categoryRepoAsync;
			this.catalogRepoAsync = catalogRepoAsync;
		}

		public async Task<IResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
		{
			var categoryAsigned = await catalogRepoAsync.GetPagedAsync(1, 1, x => x.CategoryId == request.CategoryId, default);

			if (categoryAsigned.Any())
			{
				return Result.Fail("La Categoria esta asignada");
			}

			var category = await categoryRepoAsync.GetByIdAsync(request.CategoryId);

			if (category == null)
			{
				return Result.Fail($"No se encontro la categoria con el ID {request.CategoryId}");
			}

			await categoryRepoAsync.DeleteAsync(category);
			await categoryRepoAsync.SaveChangesAsync();

			return Result.Success();
		}
	}
}
