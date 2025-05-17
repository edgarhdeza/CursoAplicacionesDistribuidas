using DWShop.Application.Features.Identity.Commands.AddRole;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWShop.Application.Validations.Identity.Role.Add
{
	public class AddRoleCommandValidator : AbstractValidator<AddRoleCommand>
	{
		public AddRoleCommandValidator()
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
