﻿using DWShop.Shared.Wrapper;
using MediatR;

namespace DWShop.Application.Features.Catalog.Commands.Create
{
	public class CreateCatalogCommand : IRequest<IResult<int>>
	{
		public string Name { get; set; } = null!;
		public int CategoryId { get; set; }
		public string Description { get; set; } = null!;
		public string Summary { get; set; } = null!;
		public decimal Price { get; set; }
		public string? PhotoURL { get; set; }
	}
}
