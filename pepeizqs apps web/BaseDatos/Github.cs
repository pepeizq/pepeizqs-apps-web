#nullable disable

using Microsoft.Data.SqlClient;

namespace BaseDatos
{
    public static class Github
    {
        public static string SacarFecha(SqlConnection conexion, string id)
        {
            string seleccionarDato = "SELECT * FROM proyectosGithub WHERE id=@id";

            using (SqlCommand comando = new SqlCommand(seleccionarDato, conexion))
            {
                comando.Parameters.AddWithValue("@id", id);

                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    if (lector.Read() == true)
                    {
                        return lector.GetString(1);
                    }
                }
            }

            return null;
        }

        public static void ActualizarFecha(SqlConnection conexion, string id, string fecha)
        {
            string sqlActualizar = "UPDATE proyectosGithub " +
                        "SET fecha=@fecha WHERE id=@id";

            SqlCommand comando = new SqlCommand(sqlActualizar, conexion);

            using (comando)
            {
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@fecha", fecha);

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
}
