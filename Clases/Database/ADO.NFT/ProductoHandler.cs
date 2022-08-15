using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Database.ADO.NFT
{
    //internal class ProductoHandler
    //{
    //}
    public class ProductoHandler
    {
        public const string ConnectionString =
            "Server=MARTINJE1\\SQLEXPRESS;" +
            "Database=SistemaGestion;" +
            "Trusted_Connection=True";

        
        /*
        public void AbrirYCerrarConexion()
        {
            using(SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM ...", sqlConnection))
                {
                    sqlConnection.Open();

                    sqlConnection.Close();
                }
            }
            
        }*/

        public List<string> GetTodasLasDescripcionesConDataReader()
        {
            List<string> descripciones = new List<string>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(
                    "SELECT * FROM Producto",sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataReader dataReader=sqlCommand.ExecuteReader())
                    {
                        if(dataReader.HasRows)
                        {
                            while(dataReader.Read())
                            {
                                descripciones.Add(dataReader.GetString(1));
                            }
                        }
                    }
                    sqlConnection.Close();
                }
            }

            return descripciones;
        }

        public List<string> GetTodasLasDescripcionesConDataAdapter()
        {
            List<string> descripciones = new List<string>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Producto", sqlConnection);
                
                sqlConnection.Open();

                DataSet resultado = new DataSet();
                sqlDataAdapter.Fill(resultado);

                sqlConnection.Close();
                
            }

            return descripciones;
        }


        public List<Producto> GetProductos()
        {
            List<Producto> productos = new List<Producto>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(
                    "SELECT * FROM Producto", sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Producto producto = new Producto();
                                producto.Id = Convert.ToInt32(dataReader["Id"]);
                                producto.Stock= Convert.ToInt32(dataReader["Stock"]);
                                producto.IdUsuario = Convert.ToInt32(dataReader["IdUsuario"]);
                                producto.Costo = Convert.ToInt32(dataReader["Costo"]);
                                producto.PrecioVenta = Convert.ToInt32(dataReader["PrecioVenta"]);
                                producto.Descripciones = dataReader["Descripciones"].ToString();

                                productos.Add(producto);
                            }
                        }
                    }
                    sqlConnection.Close();
                }
            }

            return productos;
        }
    }
}





