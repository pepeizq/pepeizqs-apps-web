namespace Herramientas
{
	public static class Calculadora
	{	
		public static string DiferenciaTiempo(this DateTime fecha, string idioma, int modo = 0)
		{
            //modos
            //0 -> hace X tiempo
            //1 -> termina en X tiempo
            //2 -> terminan en X tiempo

            string mensaje = string.Empty;
			TimeSpan diferenciaTiempo = new TimeSpan();
			
			if (modo == 0)
			{
				diferenciaTiempo = DateTime.Now.Subtract(fecha);
            }
			else
			{
				diferenciaTiempo = fecha.Subtract(DateTime.Now);
			}

			if (diferenciaTiempo <= TimeSpan.FromSeconds(60))
			{
				if (diferenciaTiempo.Seconds == 1)
				{
                    mensaje = string.Format(Idiomas.CogerCadena(idioma, "Timer" + modo.ToString() + ".String0"), diferenciaTiempo.Seconds);
                }
				else
				{
                    mensaje = string.Format(Idiomas.CogerCadena(idioma, "Timer" + modo.ToString() + ".String1"), diferenciaTiempo.Seconds);
                }				
			}
			else if (diferenciaTiempo <= TimeSpan.FromMinutes(60))
			{
				if (diferenciaTiempo.Minutes == 1)
				{
					mensaje = Idiomas.CogerCadena(idioma, "Timer" + modo.ToString() + ".String3");
				}
				else if (diferenciaTiempo.Minutes > 1)
				{
					mensaje = string.Format(Idiomas.CogerCadena(idioma, "Timer" + modo.ToString() + ".String2"), diferenciaTiempo.Minutes);
				}
			}
			else if (diferenciaTiempo <= TimeSpan.FromHours(24))
			{
				if (diferenciaTiempo.Hours == 1)
				{
					mensaje = Idiomas.CogerCadena(idioma, "Timer" + modo.ToString() + ".String5");
				}
				else if (diferenciaTiempo.Hours > 1)
				{
					mensaje = string.Format(Idiomas.CogerCadena(idioma, "Timer" + modo.ToString() + ".String4"), diferenciaTiempo.Hours);
				}
			}
			else if (diferenciaTiempo < TimeSpan.FromDays(31))
			{
				if (diferenciaTiempo.Days == 1)
				{
					if (diferenciaTiempo.Hours == 0)
					{
                        mensaje = Idiomas.CogerCadena(idioma, "Timer" + modo.ToString() + ".String17");
                    }
					else if (diferenciaTiempo.Hours == 1)
					{
						mensaje = Idiomas.CogerCadena(idioma, "Timer" + modo.ToString() + ".String16");
                    }
					else if (diferenciaTiempo.Hours > 1)
					{
                        mensaje = string.Format(Idiomas.CogerCadena(idioma, "Timer" + modo.ToString() + ".String7"), diferenciaTiempo.Hours);
                    }					
				}
				else if (diferenciaTiempo.Days > 1)
				{
					mensaje = string.Format(Idiomas.CogerCadena(idioma, "Timer" + modo.ToString() + ".String6"), diferenciaTiempo.Days);
				}
			}
			else if (diferenciaTiempo <= TimeSpan.FromDays(365))
			{
				if (diferenciaTiempo.Days > 30 && diferenciaTiempo.Days < 60)
				{
					int dias = diferenciaTiempo.Days - 30;

					if (dias > 1)
					{
                        mensaje = string.Format(Idiomas.CogerCadena(idioma, "Timer" + modo.ToString() + ".String9"), dias);
                    }
                    else if (dias == 1)
					{
                        mensaje = Idiomas.CogerCadena(idioma, "Timer" + modo.ToString() + ".String14");
                    }
					else
					{
                        mensaje = Idiomas.CogerCadena(idioma, "Timer" + modo.ToString() + ".String15");
                    }
                }
				else if (diferenciaTiempo.Days >= 60)
				{
					mensaje = string.Format(Idiomas.CogerCadena(idioma, "Timer" + modo.ToString() + ".String8"), diferenciaTiempo.Days / 30);
				}
			}
			else
			{
				if (diferenciaTiempo.Days > 365 && diferenciaTiempo.Days < 730)
				{
					int meses = (diferenciaTiempo.Days - 365) / 30;

					if (meses > 1) 
					{
                        mensaje = string.Format(Idiomas.CogerCadena(idioma, "Timer" + modo.ToString() + ".String11"), meses);
                    }
                    else if (meses == 1)
                    {
						mensaje = Idiomas.CogerCadena(idioma, "Timer" + modo.ToString() + ".String12");
                    }
					else
					{
						mensaje = Idiomas.CogerCadena(idioma, "Timer" + modo.ToString() + ".String13");
                    }
                }
				else if (diferenciaTiempo.Days >= 730)
				{
					mensaje = string.Format(Idiomas.CogerCadena(idioma, "Timer" + modo.ToString() + ".String10"), diferenciaTiempo.Days / 365);
				}
			}

			return mensaje;
		}

        public static string DiferenciaDuranteDias(DateTime fechaEmpieza, DateTime fechaTermina, string idioma)
		{
            string mensaje = string.Empty;
            TimeSpan diferenciaTiempo = new TimeSpan();
            diferenciaTiempo = fechaTermina.Subtract(fechaEmpieza);

			if (diferenciaTiempo.Days == 1)
			{
                mensaje = Idiomas.CogerCadena(idioma, "Timer3.String1");
            }
			else if (diferenciaTiempo.Days > 1)
			{
                mensaje = string.Format(Idiomas.CogerCadena(idioma, "Timer3.String2"), diferenciaTiempo.Days);
            }
			else
			{
				mensaje = Idiomas.CogerCadena(idioma, "Timer3.String1");
			}

			return mensaje;
        }
    }
}
