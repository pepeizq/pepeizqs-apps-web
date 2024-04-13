#nullable disable

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace pepeizqs_apps_web.Pages
{
	public class LastUpdatesModel : PageModel
	{
		public string idioma = string.Empty;

		private readonly ILogger<LastUpdatesModel> _logger;

		public LastUpdatesModel(ILogger<LastUpdatesModel> logger)
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
