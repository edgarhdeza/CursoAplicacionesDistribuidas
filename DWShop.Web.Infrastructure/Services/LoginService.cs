using Blazored.LocalStorage;
using DWShop.Application.Features.Identity.Commands.Login;
using DWShop.Application.Responses.Identity;
using DWShop.Client.Infrastructure.Constants;
using DWShop.Client.Infrastructure.Managers.Login;
using DWShop.Shared.Wrapper;
using DWShop.Web.Infrastructure.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;

namespace DWShop.Web.Infrastructure.Services
{
	public class LoginService : ILoginService
	{
		private readonly IAuthenticationManager authenticationManager;
		private readonly ILocalStorageService localStorageService;
		private readonly AuthenticationStateProvider authenticationStateProvider;
		private readonly HttpClient httpClient;

		public LoginService(IAuthenticationManager authenticationManager, ILocalStorageService localStorageService, 
			AuthenticationStateProvider authenticationStateProvider, HttpClient httpClient)
		{
			this.authenticationManager = authenticationManager;
			this.localStorageService = localStorageService;
			this.authenticationStateProvider = authenticationStateProvider;
			this.httpClient = httpClient;
		}

		public async Task<IResult> Login(LoginCommand command)
		{
			IResult<LoginResponse> result;

			try
			{
				result = await authenticationManager.Login(command);
			}
			catch (Exception)
			{
				return await Result.FailAsync();
			}

			if (result.Succeded)
			{
				// Guarda el token
				await localStorageService.SetItemAsStringAsync(BaseConfiguration.AuthToken, result.Data.Token);

				// Retorna la autorizacion al http
				httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(BaseConfiguration.Schema, result.Data.Token);

				await ((DWStateProvider)authenticationStateProvider).StageChanged();

				return await Result<object>.SuccessAsync(new { }, ""); // ToDo SucessAsync
			}

			// Retorna si hubo algun error
			return await Result.FailAsync(result.Messages);
		}
	}
}
