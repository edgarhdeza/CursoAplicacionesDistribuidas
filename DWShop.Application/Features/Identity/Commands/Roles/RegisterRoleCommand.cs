using DWShop.Application.Responses.Identity;
using DWShop.Shared.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWShop.Application.Features.Identity.Commands.Roles
{
	public class RegisterRoleCommand : IRequest<Result<RoleResponse>>
	{
		public string RoleName { get; set; }
	}
}
