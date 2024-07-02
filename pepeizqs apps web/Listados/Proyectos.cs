#nullable disable

namespace Listados
{
    public static class Proyectos
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

		public static List<Proyecto> DevolverProyectos(TecnologiaTipo tipo)
		{
			List<Proyecto> proyectos = new List<Proyecto>();

			foreach (var proyecto in Generar())
			{
                foreach (var tecnologia in proyecto.Tecnologias)
                {
					if (tecnologia == tipo)
					{
						proyectos.Add(proyecto);
					}
				}
			}

            if (proyectos.Count > 0)
            {
                proyectos = proyectos.OrderBy(p => p.Nombre).ToList();
            }

			return proyectos;
		}

		public static List<Proyecto> DevolverProyectos(ProyectoTipo tipo)
		{
			List<Proyecto> proyectos = new List<Proyecto>();

			foreach (var proyecto in Generar())
			{
                if (proyecto.Tipo == tipo)
                {
					proyectos.Add(proyecto);
				}
			}

			if (proyectos.Count > 0)
			{
				proyectos = proyectos.OrderBy(p => p.Nombre).ToList();
			}

			return proyectos;
		}

		public static List<Proyecto> Generar(bool azar = false)
        {
            List<Proyecto> proyectos = new List<Proyecto>();

            Proyecto proyecto1 = new Proyecto
            {
                Id = "pepeizqdeals",
                Nombre = "pepeizq's deals",
                Github = "pepeizqs-deals-web",
                Ubicacion = "/web/pepeizqs-deals",
                Color1 = "#002033",
                Color2 = "#1b2838",
                Enlace = "https://pepeizqdeals.com/",
                Tipo = ProyectoTipo.Web,
				Tecnologias = new List<TecnologiaTipo>() { TecnologiaTipo.ASPNetCore }
			};

            proyectos.Add(proyecto1);

			Proyecto proyecto2 = new Proyecto
			{
				Id = "pepeizqdeals2",
				Nombre = "pepeizq's deals",
				Github = "pepeizqs-deals-app",
				Ubicacion = "/app/pepeizqs-deals",
				Color1 = "#171a21",
				Color2 = "#2f3544",
				Tipo = ProyectoTipo.App,
                Tecnologias = new List<TecnologiaTipo>() { TecnologiaTipo.WinUI }
			};

			proyectos.Add(proyecto2);

			Proyecto proyecto3 = new Proyecto
			{
				Id = "pepeizqapps",
				Nombre = "pepeizq's apps",
				Github = "pepeizqs-apps-web",
                Color1 = "#003f3f",
				Tipo = ProyectoTipo.Web,
				Tecnologias = new List<TecnologiaTipo>() { TecnologiaTipo.ASPNetCore }
			};

			proyectos.Add(proyecto3);

            Proyecto proyecto4 = new Proyecto
            {
                Id = "tilesgames",
                Nombre = "pepeizq's Tiles for Games",
                Github = "Tiles-Games",
                Ubicacion = "/app/tiles-games",
                Enlace = "https://apps.microsoft.com/detail/9MXKL17J89JN",
				Color1 = "#171a21",
				Color2 = "#2f3544",
				Tipo = ProyectoTipo.App,
                Tecnologias = new List<TecnologiaTipo>() { TecnologiaTipo.WinUI },
                Buscador = new List<string>() { "steam", "gog", "ea play", "origin", "ubisoft", "uplay", "battlenet", "amazon", "epic games" }
            };

            proyectos.Add(proyecto4);

			Proyecto proyecto5 = new Proyecto
			{
				Id = "databasegames",
				Nombre = "Database Games",
				Github = "Database-Games",
				Ubicacion = "/app/database-games",
				Color1 = "#171a21",
				Color2 = "#2f3544",
				Tipo = ProyectoTipo.App,
				Tecnologias = new List<TecnologiaTipo>() { TecnologiaTipo.WinUI }
			};

			proyectos.Add(proyecto5);

            Proyecto proyecto6 = new Proyecto
            {
                Id = "tilesmedia",
                Nombre = "pepeizq's Tiles for Streaming",
                Github = "Tiles-Media",
                Ubicacion = "/app/tiles-media",
				Enlace = "https://apps.microsoft.com/detail/9PNFN1QNMZR9",
				Color1 = "#1a0303",
                Color2 = "#3d0707",
                Tipo = ProyectoTipo.App,
                Tecnologias = new List<TecnologiaTipo>() { TecnologiaTipo.WinUI },
                Buscador = new List<string>() { "netflix", "disney", "prime", "amazon", "spotify" }
            };

            proyectos.Add(proyecto6);

			Proyecto proyecto7 = new Proyecto
			{
				Id = "widgetsgames",
				Nombre = "pepeizq's Widgets for Games",
				Github = "Widgets-Games",
				Ubicacion = "/app/widgets-games",
				Enlace = "https://apps.microsoft.com/detail/9N6RH8C536LS",
				Color1 = "#193748",
				Color2 = "#234d65",
				Tipo = ProyectoTipo.App,
				Tecnologias = new List<TecnologiaTipo>() { TecnologiaTipo.WinUI },
                Buscador = new List<string>() { "steam", "gog", "ea play", "origin", "ubisoft", "uplay", "battlenet", "amazon", "epic games" }
            };

			proyectos.Add(proyecto7);

            Proyecto proyecto8 = new Proyecto
            {
                Id = "widgetsmedia",
                Nombre = "pepeizq's Widgets for Streaming",
                Github = "Widgets-Media",
                Ubicacion = "/app/widgets-media",
                Enlace = "https://apps.microsoft.com/detail/9NTHP669WBDD",
                Color1 = "#083116",
                Color2 = "#0e5325",
                Tipo = ProyectoTipo.App,
                Tecnologias = new List<TecnologiaTipo>() { TecnologiaTipo.WinUI },
                Buscador = new List<string>() { "netflix", "disney", "prime", "amazon", "spotify" }
            };

            proyectos.Add(proyecto8);

            Proyecto proyecto9 = new Proyecto
            {
                Id = "steamconnect",
                Nombre = "pepeizq's Steam Connect",
                Github = "Steam-Connect",
                Ubicacion = "/app/steam-connect",
                Enlace = "https://github.com/pepeizq/Steam-Connect/",
                Color1 = "#00003c",
                Color2 = "#000063",
                Tipo = ProyectoTipo.App,
                Tecnologias = new List<TecnologiaTipo>() { TecnologiaTipo.WinUI },
                Buscador = new List<string>() { "gog", "ea play", "origin", "ubisoft", "uplay", "battlenet", "amazon", "epic games" }
            };

            proyectos.Add(proyecto9);

			Proyecto proyecto10 = new Proyecto
			{
				Id = "achievements",
				Nombre = "pepeizq's Achievements for Games",
				Github = "Steam-Achievements",
				Ubicacion = "/app/achievements-for-games",
				Enlace = "https://apps.microsoft.com/detail/9MZZX81TDT20",
				Color1 = "#161616",
				Color2 = "#333333",
				Tipo = ProyectoTipo.App,
				Tecnologias = new List<TecnologiaTipo>() { TecnologiaTipo.WinUI },
                Buscador = new List<string>() { "steam" }
			};

			proyectos.Add(proyecto10);

			Proyecto proyecto11 = new Proyecto
			{
				Id = "steamgrids",
				Nombre = "pepeizq's Steam Grids",
				Github = "Steam-Grids",
				Ubicacion = "/app/steam-grids",
				Enlace = "https://github.com/pepeizq/Steam-Grids/",
				Color1 = "#32414c",
				Color2 = "#222d34",
				Tipo = ProyectoTipo.App,
				Tecnologias = new List<TecnologiaTipo>() { TecnologiaTipo.WinUI },
				Buscador = new List<string>() { "steam" }
			};

			proyectos.Add(proyecto11);

            Proyecto proyecto12 = new Proyecto
            {
                Id = "steamskins",
                Nombre = "pepeizq's Steam Skins",
                Github = "Steam-Skins-WinUI",
                Ubicacion = "/app/steam-skins",
                Enlace = "https://github.com/pepeizq/Steam-Skins-WinUI/",
                Color1 = "#202b20",
                Color2 = "#344131",
                Tipo = ProyectoTipo.App,
                Tecnologias = new List<TecnologiaTipo>() { TecnologiaTipo.WinUI },
                Buscador = new List<string>() { "steam" }
            };

            proyectos.Add(proyecto12);

            Proyecto proyecto13 = new Proyecto
            {
                Id = "cities",
                Nombre = "pepeizq's Cities",
                Github = "pepeizqs-cities",
                Ubicacion = "/game/pepeizqs-cities",
                Enlace = "https://store.steampowered.com/app/1039060/pepeizqs_Cities/",
                Color1 = "#001c33",
                Color2 = "#002c47",
                Tipo = ProyectoTipo.Juego,
                Tecnologias = new List<TecnologiaTipo>() { TecnologiaTipo.Unity },
                Buscador = new List<string>() { "steam" }
            };

            proyectos.Add(proyecto13);

            //-----------------------------------------

            if (proyectos.Count > 0)
            {
				if (azar == false)
                {
					proyectos = proyectos.OrderBy(p => p.Nombre).ToList();
				}
				else
                {
					proyectos = proyectos.OrderBy(p => Guid.NewGuid()).ToList();
				}
			}
            
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
        public List<TecnologiaTipo> Tecnologias;
        public List<string> Buscador; 
	}

	public enum ProyectoTipo
	{
		App,
        Web,
        Juego
	}

    public class ProyectoGithub
    {
        public Proyecto Proyecto;
        public string FechaGithub;
    }
}
