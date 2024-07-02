#nullable disable

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace pepeizqs_apps_web.Pages.apps
{
    public class steam_skinsModel : PageModel
    {
        public string idioma = string.Empty;

        private readonly ILogger<steam_skinsModel> _logger;

        public steam_skinsModel(ILogger<steam_skinsModel> logger)
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
