using DWShop.Web.Infrastructure.Settings;
using MudBlazor;

namespace DWShop.Web.Client.Client.Layout
{
	public partial class MainLayout
	{
		private MudTheme currentTheme;

		bool isDarkMode;

		public async Task DarkMode()
		{
			currentTheme = isDarkMode ? 
				DWTheme.DarkTheme : DWTheme.DefaultTheme;
		}

	}
}
