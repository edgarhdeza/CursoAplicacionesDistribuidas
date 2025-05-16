using AutoMapper;
using DWShop.Infrastructure.Services;
using DWShop.Shared.Wrapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		public Task<Result<string>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
