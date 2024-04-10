#nullable disable

namespace Proyectos
{
    public static class Listado
    {
        public static Proyecto DevolverProyecto(string id)
        {
            foreach (var proyecto in Generar())
            {
                if (id == proyecto.Id)
                {
                    return proyecto;
                }
            }

            return null;
        }

        public static List<Proyecto> Generar()
        {
            List<Proyecto> proyectos = new List<Proyecto>();

            Proyecto proyecto1 = new Proyecto
            {
                Id = "pepeizqdeals",
                Nombre = "pepeizq's deals",
                Github = "pepeizqs-deals-web",
                Ubicacion = "/webs/pepeizqdeals",
                Color1 = "#002033",
                Color2 = "#1b2838",
                Enlace = "https://pepeizqdeals.com/",
                Tipo = ProyectoTipo.Web,
				Tecnologias = new List<string>() { "ASP NET Core", "Blazor", ".NET 8" }
			};

            proyectos.Add(proyecto1);

			Proyecto proyecto2 = new Proyecto
			{
				Id = "pepeizqdeals2",
				Nombre = "pepeizq's deals",
				Github = "pepeizqs-deals-app",
				Ubicacion = "/apps/pepeizqdeals",
				Color1 = "#171a21",
				Color2 = "#2f3544",
				Tipo = ProyectoTipo.App,
                Tecnologias = new List<string>() { "WinUI 3", ".NET 7" }
			};

			proyectos.Add(proyecto2);

			return proyectos;
        }
    }

    public class Proyecto
    {
        public string Id;
        public string Nombre;
        public string Github;
        public string Ubicacion;
        public string Color1;
		public string Color2;
        public string Enlace;
        public ProyectoTipo Tipo;
        public List<string> Tecnologias;
	}

	public enum ProyectoTipo
	{
		App,
        Web,
        Juego
	}

}
