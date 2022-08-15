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
                        producto.id_producto = Convert.ToInt32(row["Id"]);
                        producto.stock = Convert.ToInt32(row["Stock"]);
                        producto.id_usuario = Convert.ToInt32(row["IdUsuario"]);
                        producto.descripcion = Convert.ToString(row["Descripciones"]);
                        producto.costo= Convert.ToInt32(row["Costo"]);
                        producto.precioVenta= Convert.ToInt32(row["PrecioVenta"]);
                        resultados.Add(producto);
                    }
                }
            }
            return resultados;
        }

    }
    
}
