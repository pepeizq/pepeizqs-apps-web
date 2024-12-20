#nullable disable

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace pepeizqs_apps_web.Pages.apps
{
    public class widgetsmediaModel : PageModel
    {
        public string idioma = string.Empty;

        private readonly ILogger<widgetsmediaModel> _logger;

        public widgetsmediaModel(ILogger<widgetsmediaModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
			idioma = Request.Query["language"];

			if (string.IsNullOrEmpty(idioma) == true)
			{
				try
				{
					idioma = Request.Headers["Accept-Language"].ToString().Split(";").FirstOrDefault()?.Split(",").FirstOrDefault();
				}
				catch { }
			}
		}
    }
}
