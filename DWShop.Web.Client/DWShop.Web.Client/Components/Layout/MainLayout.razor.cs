using DWShop.Web.Infrastructure.Services;
using DWShop.Web.Infrastructure.Settings;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DWShop.Web.Client.Components.Layout
{
	public partial class MainLayout
	{
		[Inject]
		public ClientPreferencesServices ClientPreferencesServices { get; set; }

		private MudTheme currentTheme = DWTheme.DefaultTheme;

		bool isDarkMode;

		public async Task DarkMode()
		{
			isDarkMode = await ClientPreferencesServices.ToogleDarkModeAsync();

			currentTheme = isDarkMode ? DWTheme.DefaultTheme : DWTheme.DarkTheme;
		}

		//protected override void OnAfterRender(bool firstRender)
		//{
		//	if (!firstRender)
		//		return;

		//	base.OnAfterRender(firstRender);
		//}

		void ToggleDrawer()
		{ 
			navOpen = !navOpen;
		}
	}
}
