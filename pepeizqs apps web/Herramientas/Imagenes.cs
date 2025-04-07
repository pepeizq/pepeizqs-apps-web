namespace Herramientas
{
	public static class Imagenes
	{
		public static string ServidorExterno(string enlace, int ancho = 0, int alto = 0)
		{
			if (string.IsNullOrEmpty(enlace) == false)
			{
				if (enlace.IndexOf("/") == 0)
				{
					enlace = "https://pepeizqapps.com" + enlace;
				}

				bool añadirServidor = true;

				if (enlace.Contains("https://hb.imgix.net/") == true)
				{
					añadirServidor = false;
				}
				else if (enlace.Contains("https://i.imgur.com/") == true)
				{
					añadirServidor = false;
				}

				if (añadirServidor == true)
				{
					enlace = "https://wsrv.nl/?n=-1&output=webp&url=" + enlace;

					if (ancho > 0 && alto > 0)
					{
						enlace = enlace + "&w=" + ancho + "&h=" + alto + "&dpr=2";
					}
				}
			}

			return enlace;
		}
	}
}
