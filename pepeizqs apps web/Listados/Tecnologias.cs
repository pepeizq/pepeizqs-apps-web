#nullable disable

namespace Listados
{
	public static class Tecnologias
	{
		public static List<Tecnologia> Generar()
		{
			List<Tecnologia> tecnologias = new List<Tecnologia>();

			Tecnologia tecnologia1 = new Tecnologia
			{
				Id = TecnologiaTipo.ASPNetCore,
				Nombre = "ASP.Net Core",
				Imagen = "aspnetcore.webp",
				MostrarNombre = false
			};

			tecnologias.Add(tecnologia1);

			Tecnologia tecnologia2 = new Tecnologia
			{
				Id = TecnologiaTipo.WinUI,
				Nombre = "WinUI",
				Imagen = "winui.webp",
				MostrarNombre = true
			};

			tecnologias.Add(tecnologia2);

            Tecnologia tecnologia3 = new Tecnologia
            {
                Id = TecnologiaTipo.Unity,
                Nombre = "Unity",
                Imagen = "unity.webp",
                MostrarNombre = false
            };

            tecnologias.Add(tecnologia3);

            return tecnologias;
		}
	}

	public enum TecnologiaTipo
	{
		ASPNetCore,
		WinUI,
		Unity
	}

	public class Tecnologia
	{
		public TecnologiaTipo Id;
		public string Nombre;
		public string Imagen;
		public bool MostrarNombre;
	}
}
