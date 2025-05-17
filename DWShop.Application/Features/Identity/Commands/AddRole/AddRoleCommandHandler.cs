using DWShop.Shared.Wrapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWShop.Application.Features.Identity.Commands.AddRole
{
	public class AddRoleCommandHandler : IRequestHandler<AddRoleCommand, Result<string>>
	{
		private readonly UserManager<IdentityUser> userManager;
		private readonly RoleManager<IdentityRole> roleManager;

		public AddRoleCommandHandler(UserManager<IdentityUser> userManager,  RoleManager<IdentityRole> roleManager)
		{
			this.userManager = userManager;
			this.roleManager = roleManager;
		}

		public async Task<Result<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
		{
			var existUser = await userManager.FindByNameAsync(request.UserName);

			if (existUser == null)
			{
				return await Result<string>.FailAsync("El usuario no existe");
			}

			var existRole = await roleManager.FindByNameAsync(request.RoleName);

			if (existRole == null)
			{
				return await Result<string>.FailAsync("El role no existe");
			}

			var result = await userManager.AddToRoleAsync(existUser, existRole.Name!);

			if (!result.Succeeded)
			{
				return await Result<string>.FailAsync("Error al asignar role");
			}

			return await Result<string>.SuccessAsync("Role asignado", "");
		}
	}
}
