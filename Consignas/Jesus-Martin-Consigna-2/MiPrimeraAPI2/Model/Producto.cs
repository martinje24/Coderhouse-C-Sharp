namespace MiPrimeraAPI2.Model
{
    public class Producto
    {
        public int id_producto { get; set; }
        public string descripcion { get; set; }
        public double costo { get; set; }
        public double precioVenta { get; set; }
        public int stock { get; set; }
        public int id_usuario { get; set; }

    }

}
