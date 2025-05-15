using AutoMapper;
using DWShop.Infrastructure.Repositories;
using DWShop.Shared.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWShop.Application.Features.Category.Commands.Create
{
	public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, IResult<int>>
	{
		private readonly IMapper mapper;
		private readonly IRepositoryAsync<Domain.Entities.Category, int> repositoryAsync;

		public CreateCategoryCommandHandler(IMapper mapper, IRepositoryAsync<Domain.Entities.Category, int> repositoryAsync)
		{ 
			this.mapper = mapper;
			this.repositoryAsync = repositoryAsync;
		}

		public async Task<IResult<int>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
		{
			var existCategory = await repositoryAsync.GetPagedAsync(1, 1, x => x.Name == request.Name, default);

			if (existCategory.Any())
			{
				return Result<int>.Fail("La Categoria ya existe");
			}

			var category = mapper.Map<Domain.Entities.Category>(request);

			await repositoryAsync.AddAsync(category);
			await repositoryAsync.SaveChangesAsync();

			return await Result<int>.SuccessAsync(category.Id, "");
		}
	}
}
