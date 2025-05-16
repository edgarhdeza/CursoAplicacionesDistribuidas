using DWShop.Application.Features.Identity.Commands.Register;
using DWShop.Shared.Wrapper;
using Microsoft.AspNetCore.Mvc;

namespace DWShop.Service.Api.Controllers
{
	public class IdentityController : BaseApiController
	{
		[HttpPost]
		public async Task<ActionResult<Result<string>>> Register([FromBody] RegisterUserCommand command) => Ok(await mediator.Send(command));
	}
}
