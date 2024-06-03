#nullable disable

using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Herramientas
{
	public class Sitemap : Controller
	{
		[HttpGet("sitemap2.xml")]
		public IActionResult Generar()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n<urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\"\r\n        xmlns:news=\"http://www.google.com/schemas/sitemap-news/0.9\">\r\n");

			string textoIndex = "<url>" + Environment.NewLine +
					"<loc>https://pepeizqapps.com/</loc>" + Environment.NewLine +
					"<changefreq>hourly</changefreq>" + Environment.NewLine +
					"<priority>0.9</priority> " + Environment.NewLine +
					"</url>";

			sb.Append(textoIndex);

			string textoActualizaciones = "<url>" + Environment.NewLine +
					"<loc>https://pepeizqapps.com/last-updates/</loc>" + Environment.NewLine +
					"<changefreq>daily</changefreq>" + Environment.NewLine +
					"<priority>0.7</priority> " + Environment.NewLine +
					"</url>";

			sb.Append(textoActualizaciones);

			foreach (var proyecto in Listados.Proyectos.Generar())
			{
				string textoProyecto = "<url>" + Environment.NewLine +
					"<loc>https://pepeizqapps.com" + proyecto.Ubicacion + "/</loc>" + Environment.NewLine +
					"<changefreq>daily</changefreq>" + Environment.NewLine +
					"<priority>0.7</priority> " + Environment.NewLine +
					"</url>";

				sb.Append(textoProyecto);
			}

			sb.Append("</urlset>");

			return new ContentResult
			{
				ContentType = "application/xml",
				Content = sb.ToString(),
				StatusCode = 200
			};
		}
	}
}
