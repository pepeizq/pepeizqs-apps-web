#nullable disable

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace pepeizqs_apps_web.Pages.games
{
    public class pepeizqs_citiesModel : PageModel
    {
        public string idioma = string.Empty;

        private readonly ILogger<pepeizqs_citiesModel> _logger;

        public pepeizqs_citiesModel(ILogger<pepeizqs_citiesModel> logger)
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
