using MiPrimeraAPI2.Model;
using System.Data;
using System.Data.SqlClient;

namespace MiPrimeraAPI2.Repository
{
    public class ProductoVendidoHandler
    {
        public const string ConnectionString =
            "Server=MARTINJE1\\SQLEXPRESS;" +
            "Database=SistemaGestion;" +
            "Trusted_Connection=True";
        public static List<ProductoVendido> GetProductosVendidos()
        {
            List<ProductoVendido> resultados = new List<ProductoVendido>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string querySelect = "SELECT * FROM ProductoVendido";
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
                    foreach (DataRow row in table.Rows)
                    {
                        ProductoVendido productoVendido = new ProductoVendido();
                        productoVendido.id_productoVendido = Convert.ToInt32(row["Id"]);
                        productoVendido.stock = Convert.ToInt32(row["Stock"]);
                        productoVendido.id_producto = Convert.ToInt32(row["IdProducto"]);
                        productoVendido.id_venta = Convert.ToInt32(row["IdVenta"]);
                        resultados.Add(productoVendido);
                    }
                }
            }
            return resultados;
        }
    }
}
