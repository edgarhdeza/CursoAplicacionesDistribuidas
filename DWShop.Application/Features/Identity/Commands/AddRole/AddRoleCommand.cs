using DWShop.Shared.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWShop.Application.Features.Identity.Commands.AddRole
{
	public class AddRoleCommand : IRequest<Result<string>>
	{
		public string UserName { get; set; } = null!;
		public string RoleName { get; set; } = null!;
	}
}
