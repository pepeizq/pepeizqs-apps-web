#nullable disable

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace pepeizqs_apps_web.Pages.apps
{
	public class pepeizqdealsModel : PageModel
	{
		public string idioma = string.Empty;

		private readonly ILogger<IndexModel> _logger;

		public pepeizqdealsModel(ILogger<IndexModel> logger)
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
