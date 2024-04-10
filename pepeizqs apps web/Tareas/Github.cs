#nullable disable

using Herramientas;
using Microsoft.Data.SqlClient;

namespace Tareas
{
	public class TareaGithub : BackgroundService
	{
		private readonly ILogger<TareaGithub> _logger;
		private readonly IServiceScopeFactory _factoria;
		private readonly IDecompiladores _decompilador;

		public TareaGithub(ILogger<TareaGithub> logger, IServiceScopeFactory factory, IDecompiladores decompilador)
		{
			_logger = logger;
			_factoria = factory;
			_decompilador = decompilador;
		}

		protected override async Task ExecuteAsync(CancellationToken tokenParar)
		{
			using PeriodicTimer timer = new(TimeSpan.FromSeconds(60));

			while (await timer.WaitForNextTickAsync(tokenParar))
			{
				using (AsyncServiceScope scope = _factoria.CreateAsyncScope())
				{
					SqlConnection conexion = Herramientas.BaseDatos.Conectar();

                    TimeSpan tiempoSiguiente = TimeSpan.FromMinutes(30);

                    if (BaseDatos.Tareas.ComprobarTareaUso(conexion, "github", tiempoSiguiente) == true)
                    {
                        BaseDatos.Tareas.ActualizarTareaUso(conexion, "github", DateTime.Now);

                        try
                        {
							foreach (var proyecto in Proyectos.Listado.Generar())
							{
                                string fecha = await Github.UltimaModificacion(proyecto.Github);

                                if (string.IsNullOrEmpty(fecha) == false)
                                {
                                    BaseDatos.Github.ActualizarFecha(conexion, proyecto.Github, fecha);
                                }
                                else
                                {
                                    BaseDatos.Github.ActualizarFecha(conexion, proyecto.Github, "0");
                                }
                            }                          
                        }
                        catch 
                        {
                           
                        }
                    }
                }
			}
		}

		public override async Task StopAsync(CancellationToken stoppingToken)
		{
			await base.StopAsync(stoppingToken);
		}
	}
}
