using DWShop.Application.Features.Identity.Commands.AddRole;
using DWShop.Application.Features.Identity.Commands.GetRoles;
using DWShop.Application.Features.Identity.Commands.RemoveRole;
using DWShop.Application.Features.Identity.Commands.Roles;
using DWShop.Application.Responses.Identity;
using DWShop.Shared.Wrapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DWShop.Service.Api.Controllers
{
	[Authorize(Roles = "admin")]
	public class RoleController : BaseApiController
	{
		[HttpPost("Register")]
		public async Task<ActionResult<Result<RoleResponse>>> Register([FromBody] RegisterRoleCommand command) => Ok(await mediator.Send(command));

		[HttpPost("Add")]
		public async Task<ActionResult<Result<string>>> Add([FromBody] AddRoleCommand command) => Ok(await mediator.Send(command));

		[HttpDelete]
		public async Task<ActionResult<Result<string>>> Remove([FromBody] RemoveRoleCommand command) => Ok(await mediator.Send(command));

		[HttpGet("{UserName}")]
		public async Task<ActionResult<Result<IEnumerable<RoleResponse>>>> GetAll(string UserName) => Ok(await mediator.Send(new GetRolesCommand() { UserName = UserName }));
	}
}
