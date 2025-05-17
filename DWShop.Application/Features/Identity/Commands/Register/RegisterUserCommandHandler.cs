using AutoMapper;
using DWShop.Application.Features.Identity.Commands.Login;
using DWShop.Application.Responses.Identity;
using DWShop.Infrastructure.Services;
using DWShop.Shared.Wrapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DWShop.Application.Features.Identity.Commands.Register
{
	public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Result<LoginResponse>>
	{
		private readonly UserManager<IdentityUser> userManager;
		private readonly IAccountService accountService;
		private readonly IMapper mapper;
		private readonly IMediator mediator;

		public RegisterUserCommandHandler(UserManager<IdentityUser> userManager, 
			IAccountService accountService, 
			IMapper mapper, IMediator mediator)
		{
			this.userManager = userManager;
			this.accountService = accountService;
			this.mapper = mapper;
			this.mediator = mediator;
		}

		public async Task<Result<LoginResponse>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
		{
			var user = mapper.Map<IdentityUser>(request);

			if (await accountService.UserExists(request.UserName))
			{
				return await Result<LoginResponse>.FailAsync("El usuario ya existe");
			}

			user.Id = Guid.NewGuid().ToString();

			var result = await userManager.CreateAsync(user, request.Password);

			if (!result.Succeeded)
			{
				return await Result<LoginResponse>.FailAsync(result.Errors.Select(x => x.Description).ToList());
			}

			var loginCommand = new LoginCommand
			{
				Password = request.Password,
				UserName = request.UserName,
			};

			return await mediator.Send(loginCommand);

			// var token = await accountService.GetToken(user);
			// return Result<string>.Success(token, "");
		}
	}
}
