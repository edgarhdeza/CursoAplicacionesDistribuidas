using DWShop.Application.Features.Catalog.Commands.Delete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWShop.Application.Validations.Catalog.Command.Delete
{
	public class DeleteCatalogCommandValidator : AbstractValidator<DeleteCatalogCommand>
	{
		public DeleteCatalogCommandValidator() 
		{
			RuleFor(x => x.CatalogId)
				.GreaterThan(0)
				.NotNull();
		}
	}
}
