using DWShop.Application.Features.Identity.Commands.Roles;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWShop.Application.Validations.Identity.Role.Create
{
	public class CreateRoleCommandValidator : AbstractValidator<RegisterRoleCommand>
	{
		public CreateRoleCommandValidator()
		{
			RuleFor(x => x.RoleName)
				.NotEmpty()
				.NotNull();
		}
	}
}
