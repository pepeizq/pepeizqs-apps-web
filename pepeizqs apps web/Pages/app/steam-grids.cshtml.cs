#nullable disable

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace pepeizqs_apps_web.Pages.apps
{
    public class steam_gridsModel : PageModel
    {
		public string idioma = string.Empty;

		private readonly ILogger<steam_gridsModel> _logger;

		public steam_gridsModel(ILogger<steam_gridsModel> logger)
		{
			_logger = logger;
		}

		public void OnGet()
		{
			try
			{
				idioma = Request.Headers["Accept-Language"].ToString().Split(";").FirstOrDefault()?.Split(",").FirstOrDefault();
			}
			catch { }
		}
	}
}
