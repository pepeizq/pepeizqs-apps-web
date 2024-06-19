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
							foreach (var proyecto in Listados.Proyectos.Generar())
							{ 
								GithubAPI api = await Github.CargarAPI(proyecto.Github);

                                if (string.IsNullOrEmpty(api.UltimaModificacion) == false && int.Parse(api.Estrellas) > -1 && int.Parse(api.Forks) > -1)
                                {
                                    BaseDatos.Github.Actualizar(conexion, proyecto.Github, api.UltimaModificacion, api.Estrellas, api.Forks, api.Suscriptores);
                                }
                                else
                                {
                                    BaseDatos.Github.Actualizar(conexion, proyecto.Github, "0", "0", "0", "0");
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
