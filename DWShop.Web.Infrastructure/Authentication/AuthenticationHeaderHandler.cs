using Blazored.LocalStorage;
using DWShop.Client.Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DWShop.Web.Infrastructure.Authentication
{
	public class AuthenticationHeaderHandler : DelegatingHandler
	{
		private readonly ILocalStorageService localStorageService;

		public AuthenticationHeaderHandler(ILocalStorageService localStorageService)
		{
			this.localStorageService = localStorageService;
		}

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			if (request.Headers.Authorization?.Scheme != BaseConfiguration.Schema)
			{
				var savedToken = await localStorageService.GetItemAsync<string>(BaseConfiguration.AuthToken);

				if (!string.IsNullOrEmpty(savedToken))
				{
					request.Headers.Authorization = new AuthenticationHeaderValue(BaseConfiguration.Schema, savedToken);
				}
			}

			return await base.SendAsync(request, cancellationToken);
		}
	}
}
