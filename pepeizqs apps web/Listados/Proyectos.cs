﻿#nullable disable

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

			return proyectos;
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
				Tecnologias = new List<TecnologiaTipo>() { TecnologiaTipo.ASPNetCore },
                MostrarPortada = true
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
                Tecnologias = new List<TecnologiaTipo>() { TecnologiaTipo.WinUI },
                MostrarPortada = true
			};

			proyectos.Add(proyecto2);

			Proyecto proyecto3 = new Proyecto
			{
				Id = "pepeizqapps",
				Nombre = "pepeizq's apps",
				Github = "pepeizqs-apps-web",
				Tipo = ProyectoTipo.Web,
				Tecnologias = new List<TecnologiaTipo>() { TecnologiaTipo.ASPNetCore },
				MostrarPortada = false
			};

			proyectos.Add(proyecto3);

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
        public bool MostrarPortada;
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