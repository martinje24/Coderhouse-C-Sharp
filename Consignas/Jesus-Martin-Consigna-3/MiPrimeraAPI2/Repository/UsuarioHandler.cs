using MiPrimeraAPI2.Model;
using System.Data;
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

        public static Usuario GetUsuarioByContraseña(string nombreUsuario, string contraseña)
        {
            Usuario resultado = new Usuario();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string querySelect = "SELECT * FROM Usuario "+
                    $"WHERE NombreUsuario = '{nombreUsuario}' "+
                    $"AND Contraseña = '{contraseña}'";
                using (SqlCommand sqlCommand = new SqlCommand(querySelect, sqlConnection))
                {
                    sqlConnection.Open();
                    //usando el data reader
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        //Nos aseguramos que haya filas
                        if (dataReader.HasRows)
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
                                resultado=usuario;
                            }
                        }
                    }
                    sqlConnection.Close();
                }
            }
            return resultado;
        }

        public static bool EliminarUsuario(int id)
        {
            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryDelete = "DELETE FROM Producto WHERE Producto.IdUsuario = @id; " +
                                     "DELETE FROM Usuario WHERE Usuario.Id = @id";
                SqlParameter sqlParameter = new SqlParameter("id",System.Data.SqlDbType.BigInt);
                sqlParameter.Value = id;
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                {
                    sqlCommand.Parameters.Add(sqlParameter);
                    int numberOfRows=sqlCommand.ExecuteNonQuery();
                    if(numberOfRows>0)
                    {
                        resultado=true;
                    }
                }
                sqlConnection.Close();
                
            }
            return resultado;
        }

        public static bool CrearUsuario(Usuario usuario)
        {
            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryInsert = "INSERT INTO [SistemaGestion].[dbo].[Usuario] " +
                    "(Nombre, Apellido, NombreUsuario, Contraseña, Mail) VALUES " +
                    "(@nombreParameter, @apellidoParameter, @nombreUsuarioParameter, @contraseñaParameter, @mailParameter);";

                SqlParameter nombreParameter = new SqlParameter("nombreParameter", SqlDbType.VarChar) { Value = usuario.Nombre };
                SqlParameter apellidoParameter = new SqlParameter("apellidoParameter", SqlDbType.VarChar) { Value = usuario.Apellido };
                SqlParameter nombreUsuarioParameter = new SqlParameter("nombreUsuarioParameter", SqlDbType.VarChar) { Value = usuario.NombreUsuario };
                SqlParameter contraseñaParameter = new SqlParameter("contraseñaParameter", SqlDbType.VarChar) { Value = usuario.Contraseña };
                SqlParameter mailParameter = new SqlParameter("mailParameter", SqlDbType.VarChar) { Value = usuario.Mail };

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                {
                    sqlCommand.Parameters.Add(nombreParameter);
                    sqlCommand.Parameters.Add(apellidoParameter);
                    sqlCommand.Parameters.Add(nombreUsuarioParameter);
                    sqlCommand.Parameters.Add(contraseñaParameter);
                    sqlCommand.Parameters.Add(mailParameter);

                    int numberOfRows = sqlCommand.ExecuteNonQuery(); // Se ejecuta la sentencia sql

                    if (numberOfRows > 0)
                    {
                        resultado = true;
                    }
                }

                sqlConnection.Close();
            }

            return resultado;
        }

        public static bool ModificarNombreDeUsuario(Usuario usuario)
        {
            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryInsert = "UPDATE [SistemaGestion].[dbo].[Usuario] " +
                    "SET Nombre = @nombre, Apellido=@apellido " +
                    "WHERE Id = @id ";

                
                SqlParameter idParameter = new SqlParameter("id", SqlDbType.BigInt) { Value = usuario.Id };
                SqlParameter nombreParameter = new SqlParameter("nombre", SqlDbType.VarChar) { Value = usuario.Nombre };
                SqlParameter apellidoParameter = new SqlParameter("apellido", SqlDbType.VarChar) { Value = usuario.Apellido };

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                {
                    sqlCommand.Parameters.Add(nombreParameter);
                    sqlCommand.Parameters.Add(idParameter);
                    sqlCommand.Parameters.Add(apellidoParameter);

                    int numberOfRows = sqlCommand.ExecuteNonQuery(); // Se ejecuta la sentencia sql

                    if (numberOfRows > 0)
                    {
                        resultado = true;
                    }
                }

                sqlConnection.Close();
            }

            return resultado;
        }

    }
}
