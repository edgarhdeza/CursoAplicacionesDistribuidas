using AutoMapper;
using DWShop.Infrastructure.Services;
using DWShop.Shared.Wrapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DWShop.Application.Features.Identity.Commands.Register
{
	public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Result<string>>
	{
		private readonly UserManager<IdentityUser> userManager;
		private readonly IAccountService accountService;
		private readonly IMapper mapper;

		public RegisterUserCommandHandler(UserManager<IdentityUser> userManager, IAccountService accountService, IMapper mapper)
		{
			this.userManager = userManager;
			this.accountService = accountService;
			this.mapper = mapper;
		}

		public async Task<Result<string>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
		{
			var user = mapper.Map<IdentityUser>(request);

			if (await accountService.UserExists(request.UserName))
			{
				return await Result<string>.FailAsync("El usuario ya existe");
			}

			user.Id = Guid.NewGuid().ToString();

			var result = await userManager.CreateAsync(user, request.Password);

			if (!result.Succeeded)
			{
				return await Result<string>.FailAsync(result.Errors.Select(x => x.Description).ToList());
			}

			var token = await accountService.GetToken(user);

			return Result<string>.Success(token, "");
		}
	}
}
