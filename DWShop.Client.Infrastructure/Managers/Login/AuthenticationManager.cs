using DWShop.Application.Features.Identity.Commands.Login;
using DWShop.Application.Responses.Identity;
using DWShop.Client.Infrastructure.Extensions;
using DWShop.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DWShop.Client.Infrastructure.Managers.Login
{
	public class AuthenticationManager : IAuthenticationManager
	{
		private readonly HttpClient httpClient;

		public AuthenticationManager(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}

		public async Task<IResult<LoginResponse>> Login(LoginCommand command)
		{
			var response = await httpClient.PostAsJsonAsync("Identity/login", command);
			var result = await response.ToResult<LoginResponse>();

			return result;
		}
	}
}
