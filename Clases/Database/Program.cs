
namespace Database.ADO.NFT
{
    public class ProbarObjetos
    {
        static void Main(string[] args)
        {
            ProductoHandler productoHandler=new ProductoHandler();

            List<string> descripciones = productoHandler.GetTodasLasDescripcionesConDataAdapter();

            foreach (string descripcion in descripciones)
            {
                Console.WriteLine(descripcion);
            }
        }
    }
}

