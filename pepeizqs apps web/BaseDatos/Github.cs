#nullable disable

using Microsoft.Data.SqlClient;

namespace BaseDatos
{
    public static class Github
    {
        public static GithubBaseDatos Buscar(SqlConnection conexion, string id)
        {
            string seleccionarDato = "SELECT * FROM proyectosGithub WHERE id=@id";

            using (SqlCommand comando = new SqlCommand(seleccionarDato, conexion))
            {
                comando.Parameters.AddWithValue("@id", id);

                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    if (lector.Read() == true)
                    {
						GithubBaseDatos datos = new GithubBaseDatos
						{
							Fecha = lector.GetString(1),
							Estrellas = int.Parse(lector.GetString(2)),
							Forks = int.Parse(lector.GetString(3)),
                            Suscriptores = int.Parse(lector.GetString(4))
						};

						return datos;
                    }
                }
            }

            return null;
        }

		public static List<GithubBaseDatos> Todo(SqlConnection conexion)
		{
            List<GithubBaseDatos> listaDatos = new List<GithubBaseDatos>();

			string seleccionarDato = "SELECT * FROM proyectosGithub";

			using (SqlCommand comando = new SqlCommand(seleccionarDato, conexion))
			{
				using (SqlDataReader lector = comando.ExecuteReader())
				{
					while (lector.Read())
					{
						GithubBaseDatos datos = new GithubBaseDatos
						{
							Fecha = lector.GetString(1),
							Estrellas = int.Parse(lector.GetString(2)),
							Forks = int.Parse(lector.GetString(3)),
							Suscriptores = int.Parse(lector.GetString(4))
						};

						listaDatos.Add(datos);
					}
				}
			}

			return listaDatos;
		}

		public static void Actualizar(SqlConnection conexion, string id, string fecha, string estrellas, string forks, string suscriptores)
        {
            string sqlActualizar = "UPDATE proyectosGithub " +
                        "SET fecha=@fecha, estrellas=@estrellas, forks=@forks, suscriptores=@suscriptores WHERE id=@id";

            SqlCommand comando = new SqlCommand(sqlActualizar, conexion);

            using (comando)
            {
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@fecha", fecha);
                comando.Parameters.AddWithValue("@estrellas", estrellas);
                comando.Parameters.AddWithValue("@forks", forks);
                comando.Parameters.AddWithValue("@suscriptores", suscriptores);

                SqlDataReader lector = comando.ExecuteReader();

                try
                {
                    comando.ExecuteNonQuery();
                }
                catch
                {

                }
            }
        }
    }

	public class GithubBaseDatos
	{
		public string Fecha { get; set; }
		public int Estrellas { get; set; }
		public int Forks { get; set; }
        public int Suscriptores { get; set; }
	}
}
