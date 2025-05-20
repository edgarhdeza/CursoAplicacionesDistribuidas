using AutoMapper;
using DWShop.Application.Responses.Identity;
using DWShop.Shared.Wrapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWShop.Application.Features.Identity.Commands.Roles
{
	public class RegisterRoleCommandHandler : IRequestHandler<RegisterRoleCommand, Result<RoleResponse>>
	{
		private readonly RoleManager<IdentityRole> roleManager;
		private readonly IMapper mapper;

		public RegisterRoleCommandHandler(RoleManager<IdentityRole> roleManager, IMapper mapper)
		{
			this.roleManager = roleManager;
			this.mapper = mapper;
		}

		public async Task<Result<RoleResponse>> Handle(RegisterRoleCommand request, CancellationToken cancellationToken)
		{
			var exist = await roleManager.FindByNameAsync(request.RoleName);

			if (exist != null)
			{
				return await Result<RoleResponse>.FailAsync("El role ya existe");
			}

			var result = await roleManager.CreateAsync(new() { Name = request.RoleName });

			if (!result.Succeeded)
			{
				return await Result<RoleResponse>.FailAsync("No se pudo registrar el role");
			}

			var role = await roleManager.FindByNameAsync(request.RoleName);

			var roleResult = mapper.Map<RoleResponse>(role);


			return await Result<RoleResponse>.SuccessAsync(roleResult, "");
		}
	}
}
