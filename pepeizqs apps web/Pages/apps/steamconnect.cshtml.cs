#nullable disable

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace pepeizqs_apps_web.Pages.apps
{
    public class steamconnectModel : PageModel
    {
        public string idioma = string.Empty;

        private readonly ILogger<steamconnectModel> _logger;

        public steamconnectModel(ILogger<steamconnectModel> logger)
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
