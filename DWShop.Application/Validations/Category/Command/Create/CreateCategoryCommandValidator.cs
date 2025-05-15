using DWShop.Application.Features.Category.Commands.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWShop.Application.Validations.Category.Command.Create
{
	public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
	{
		public CreateCategoryCommandValidator()
		{
			RuleFor(x => x.Name)
				.NotEmpty()
				.NotNull();
		}
	}
}
