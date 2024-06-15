#nullable disable

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace pepeizqs_apps_web.Pages.apps
{
    public class achievements_for_gamesModel : PageModel
    {
        public string idioma = string.Empty;

        private readonly ILogger<achievements_for_gamesModel> _logger;

        public achievements_for_gamesModel(ILogger<achievements_for_gamesModel> logger)
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
