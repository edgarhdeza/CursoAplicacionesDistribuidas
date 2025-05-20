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

namespace DWShop.Application.Features.Identity.Commands.GetRoles
{
	public class GetRolesCommandHandler : IRequestHandler<GetRolesCommand, Result<IEnumerable<RoleResponse>>>
	{
		private readonly UserManager<IdentityUser> userManager;
		private readonly RoleManager<IdentityRole> roleManager;
		private readonly IMapper mapper;

		public GetRolesCommandHandler(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
		{
			this.userManager = userManager;
			this.roleManager = roleManager;
			this.mapper = mapper;
		}

		public async Task<Result<IEnumerable<RoleResponse>>> Handle(GetRolesCommand request, CancellationToken cancellationToken)
		{

			var existUser = await userManager.FindByNameAsync(request.UserName);

			if (existUser == null)
			{
				return await Result<IEnumerable<RoleResponse>>.FailAsync("El usuario no existe");
			}

			var roles = await userManager.GetRolesAsync(existUser);

			if (roles is null)
			{
				return await Result<IEnumerable<RoleResponse>>.FailAsync("El usuario no tiene roles");
			}

			var rolesAsignados = new List<RoleResponse>();

			// Como mapear la lista ToDo

			foreach (var tmp in roles)
			{
				var roleInfo = await roleManager.FindByNameAsync(tmp);

				rolesAsignados.Add(new()
				{
					Name = roleInfo.Name,
					Id = roleInfo.Id
				});
			}

			return Result<IEnumerable<RoleResponse>>.Success(rolesAsignados, "");
		}
	}
}
