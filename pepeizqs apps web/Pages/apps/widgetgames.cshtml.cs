#nullable disable

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace pepeizqs_apps_web.Pages.apps
{
    public class widgetgamesModel : PageModel
    {
		public string idioma = string.Empty;

		private readonly ILogger<widgetgamesModel> _logger;

		public widgetgamesModel(ILogger<widgetgamesModel> logger)
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
