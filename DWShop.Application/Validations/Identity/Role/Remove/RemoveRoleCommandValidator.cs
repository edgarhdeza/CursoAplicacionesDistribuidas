using DWShop.Application.Features.Identity.Commands.RemoveRole;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWShop.Application.Validations.Identity.Role.Remove
{
	public class RemoveRoleCommandValidator : AbstractValidator<RemoveRoleCommand>
	{
		public RemoveRoleCommandValidator()
		{
			RuleFor(x => x.UserName)
				.NotEmpty()
				.NotNull();

			RuleFor(x => x.RoleName)
				.NotEmpty()
				.NotNull();
		}
	}
}
