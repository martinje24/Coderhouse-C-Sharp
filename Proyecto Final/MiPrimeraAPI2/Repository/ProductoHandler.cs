using MiPrimeraAPI2.Model;
using System.Data;
using System.Data.SqlClient;

namespace MiPrimeraAPI2.Repository
{
    public static class ProductoHandler
    {
        public const string ConnectionString =
            "Server=MARTINJE1\\SQLEXPRESS;" +
            "Database=SistemaGestion;" +
            "Trusted_Connection=True";
        public static List<Producto> GetProductos()
        {
            List<Producto> resultados = new List<Producto>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string querySelect = "SELECT * FROM Producto";
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Connection.Open();
                    sqlCommand.CommandText = querySelect;

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.SelectCommand = sqlCommand;

                    DataTable table = new DataTable();
                    sqlDataAdapter.Fill(table);
                    sqlCommand.Connection.Close();
                    foreach(DataRow row in table.Rows)
                    {
                        Producto producto = new Producto();
                        producto.id = Convert.ToInt32(row["Id"]);
                        producto.stock = Convert.ToInt32(row["Stock"]);
                        producto.id_Usuario = Convert.ToInt32(row["IdUsuario"]);
                        producto.descripciones = Convert.ToString(row["Descripciones"]);
                        producto.costo= Convert.ToInt32(row["Costo"]);
                        producto.precioVenta= Convert.ToInt32(row["PrecioVenta"]);
                        resultados.Add(producto);
                    }
                }
            }
            return resultados;
        }
        
        //Crear Producto
        public static bool CrearProducto(Producto producto)
        {
            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryInsert = "INSERT INTO [SistemaGestion].[dbo].[Producto] " +
                    "(Descripciones,Costo,PrecioVenta,Stock,IdUsuario) VALUES " +
                    "(@descripcionesParameter, @costoParameter, @precioVentaParameter, @stockParameter, @idUsuarioParameter);";

                SqlParameter descripcionesParameter = new SqlParameter("descripcionesParameter", SqlDbType.VarChar) { Value = producto.descripciones };
                SqlParameter costoParameter = new SqlParameter("costoParameter", SqlDbType.BigInt) { Value = producto.costo };
                SqlParameter precioVentaParameter = new SqlParameter("precioVentaParameter", SqlDbType.BigInt) { Value = producto.precioVenta };
                SqlParameter stockParameter = new SqlParameter("stockParameter", SqlDbType.BigInt) { Value = producto.precioVenta };
                SqlParameter idUsuarioParameter = new SqlParameter("idUsuarioParameter", SqlDbType.BigInt) { Value = producto.id_Usuario };

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                {
                    sqlCommand.Parameters.Add(descripcionesParameter);
                    sqlCommand.Parameters.Add(costoParameter);
                    sqlCommand.Parameters.Add(precioVentaParameter);
                    sqlCommand.Parameters.Add(stockParameter);
                    sqlCommand.Parameters.Add(idUsuarioParameter);

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


        //ModificarCamposDeProducto
        public static bool ModificarCamposDeProducto(Producto producto)
        {
            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryInsert = "UPDATE [SistemaGestion].[dbo].[Producto] " +
                    "SET Descripciones=@descripcion,Costo=@costo,PrecioVenta=@precio,Stock=@stock,IdUsuario=@id_usuario " +
                    "WHERE Id = @id ";

                SqlParameter idParameter = new SqlParameter("id", SqlDbType.BigInt) { Value = producto.id };
                SqlParameter descripcionParameter = new SqlParameter("descripcion", SqlDbType.VarChar) { Value = producto.descripciones };
                SqlParameter stockParameter = new SqlParameter("stock", SqlDbType.BigInt) { Value = producto.stock };
                SqlParameter precioParameter = new SqlParameter("precio", SqlDbType.BigInt) { Value = producto.precioVenta };
                SqlParameter costoParameter = new SqlParameter("costo", SqlDbType.BigInt) { Value = producto.costo };
                SqlParameter id_usuarioParameter = new SqlParameter("id_usuario", SqlDbType.BigInt) { Value = producto.id_Usuario };

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                {
                    sqlCommand.Parameters.Add(idParameter);
                    sqlCommand.Parameters.Add(descripcionParameter);
                    sqlCommand.Parameters.Add(stockParameter);
                    sqlCommand.Parameters.Add(precioParameter);
                    sqlCommand.Parameters.Add(costoParameter);
                    sqlCommand.Parameters.Add(id_usuarioParameter);

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

        //Eliminar Producto
        public static bool EliminarProducto(int id)
        {
            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryDelete = "DELETE FROM SistemaGestion.dbo.Producto "+
                                     "WHERE Id = @id; ";
                SqlParameter sqlParameter = new SqlParameter("id", System.Data.SqlDbType.BigInt);
                sqlParameter.Value = id;
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                {
                    sqlCommand.Parameters.Add(sqlParameter);
                    int numberOfRows = sqlCommand.ExecuteNonQuery();
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
