using MiPrimeraAPI2.Model;
using System.Data;
using System.Data.SqlClient;

namespace MiPrimeraAPI2.Repository
{
    public class VentaHandler
    {
        public const string ConnectionString =
            "Server=MARTINJE1\\SQLEXPRESS;" +
            "Database=SistemaGestion;" +
            "Trusted_Connection=True";
        public static List<Venta> GetVentas()
        {
            List<Venta> resultados = new List<Venta>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string querySelect = "SELECT * FROM Venta";
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
                        Venta venta = new Venta();
                        venta.id_venta = Convert.ToInt32(row["Id"]);
                        venta.comentarios = Convert.ToString(row["Comentarios"]);
                        resultados.Add(venta);
                    }
                }
            }
            return resultados;
        }
    }
}
