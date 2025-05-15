using DWShop.Application.Features.Category.Commands.Delete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWShop.Application.Validations.Category.Command.Delete
{
	public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
	{
		public DeleteCategoryCommandValidator()
		{
			RuleFor(x => x.CategoryId)
				.GreaterThan(0)
				.NotNull();
		}
	}
}
