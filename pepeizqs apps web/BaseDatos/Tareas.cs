#nullable disable

using Microsoft.Data.SqlClient;

namespace BaseDatos
{
	public static class Tareas
	{
		public static bool ComprobarTareaUso(SqlConnection conexion, string id, TimeSpan tiempo)
		{
            string seleccionarTarea = "SELECT * FROM tareas WHERE id=@id";

            using (SqlCommand comando = new SqlCommand(seleccionarTarea, conexion))
            {
                comando.Parameters.AddWithValue("@id", id);

                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    if (lector.Read() == true)
                    {
						DateTime ultimaComprobacion = DateTime.Parse(lector.GetString(1));

                        if ((DateTime.Now - ultimaComprobacion) < tiempo)
						{
							return false;
						}
                    }
                }
            }

			return true;
        }

        public static void ActualizarTareaUso(SqlConnection conexion, string id, DateTime fecha)
		{
            string sqlActualizar = "UPDATE tareas " +
                        "SET fecha=@fecha WHERE id=@id";

            SqlCommand comando = new SqlCommand(sqlActualizar, conexion);

            using (comando)
            {
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@fecha", fecha.ToString());

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

	public class BaseDatosTarea
	{
		public string id;
		public DateTime fecha;
	}
}
