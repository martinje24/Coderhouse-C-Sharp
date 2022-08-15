using MiPrimeraAPI2.Model;
using System.Data.SqlClient;

namespace MiPrimeraAPI2.Repository
{
    public static class UsuarioHandler //Las clases son estáticas pero lo que devuelven es dinámico
    {
        public const string ConnectionString =
            "Server=MARTINJE1\\SQLEXPRESS;" +
            "Database=SistemaGestion;" +
            "Trusted_Connection=True";
        public static List<Usuario> GetUsuarios()
        {
            List<Usuario> resultados = new List<Usuario>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string querySelect = "SELECT * FROM Usuario";
                using (SqlCommand sqlCommand=new SqlCommand(querySelect, sqlConnection))
                {
                    sqlConnection.Open();
                    //usando el data reader
                    using(SqlDataReader dataReader=sqlCommand.ExecuteReader())
                    {
                        //Nos aseguramos que haya filas
                        if(dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Usuario usuario = new Usuario();
                                usuario.Id = Convert.ToInt32(dataReader["Id"]);
                                usuario.Nombre = dataReader["Nombre"].ToString();
                                usuario.Apellido = Convert.ToString(dataReader["Apellido"]);
                                usuario.NombreUsuario = Convert.ToString(dataReader["NombreUsuario"]);
                                usuario.Contraseña = Convert.ToString(dataReader["Contraseña"]);
                                usuario.Mail = Convert.ToString(dataReader["Mail"]);
                                resultados.Add(usuario);
                            }
                        }
                    }
                    sqlConnection.Close();
                }
            }
            return resultados;
        }
    }
}
