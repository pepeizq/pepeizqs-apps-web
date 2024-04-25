#nullable disable

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace pepeizqs_apps_web.Pages.apps
{
    public class tilesmediaModel : PageModel
    {
        public string idioma = string.Empty;

        private readonly ILogger<tilesmediaModel> _logger;

        public tilesmediaModel(ILogger<tilesmediaModel> logger)
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
