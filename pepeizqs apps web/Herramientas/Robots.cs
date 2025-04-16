#nullable disable

using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Herramientas
{
	public class Robots : Controller
	{
		[HttpGet("robots.txt")]
		public IActionResult Ejecutar()
		{
			StringBuilder sb = new StringBuilder();

			sb.Append(@"User-agent: *

Disallow: /link/*

Sitemap: https://pepeizqapps.com/sitemap.xml");

			return new ContentResult
			{
				Content = sb.ToString(),
				StatusCode = 200
			};
		}
	}
}