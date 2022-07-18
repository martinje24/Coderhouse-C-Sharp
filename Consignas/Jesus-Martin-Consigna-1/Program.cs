namespace Proyecto
{
    class ProbarObjetos
    {
        static void Main(string[] args) //Método público del compilador que no devuelve nada y no se necesita instanciar
        {
            Usuario usuario = new Usuario(1, "Patrick", "Hernández", "patrick.her@coderhouse.com", "Holiwis");
            
            
        }
    }

    public class Usuario //Cream,os la Clase Usuario
    {

        protected int id_usuario { get; set;}
        protected string nombre { get; set; }
        protected string apellido { get; set; }
        protected string email { get; set; }
        protected string password { get; set; }
        public Usuario() //Constructor No Parametrizado
        {
            this.id_usuario = 0;
            this.nombre = string.Empty;
            this.apellido = string.Empty;
            this.email = string.Empty;
            this.password = string.Empty;
        }
        public Usuario(int id_usuario)
        {
            this.id_usuario = id_usuario;
            this.nombre = string.Empty;
            this.apellido = string.Empty;
            this.email = string.Empty;
            this.password = string.Empty;
        }
        public Usuario(int id_usuario, string nombre, string apellido, string email, string password)
        {
            this.id_usuario = id_usuario;
            this.nombre = nombre;
            this.apellido = apellido;
            this.email = email;
            this.password = password;
        }
        
    }

    class Producto : Usuario
    {
        public int id_producto;
        public string descripcion;
        public double costo;
        public double precioVenta;
        public int stock;

        public Producto(int id_producto, string descripcion, double costo, double precioVenta, int stock,
            int id_usuario) : base(id_usuario) //La clase Producto hereda de Usuario
        {
            this.id_producto = id_producto;
            this.descripcion = descripcion;
            this.costo = costo;
            this.precioVenta = precioVenta;
            this.stock = stock;
        }

        public Producto(int id_usuario, int stock) : base(id_usuario) //La clase Producto hereda de Usuario
        {
            this.id_producto = 0;
            this.descripcion = string.Empty;
            this.costo = stock;
            this.precioVenta = 0;
            this.stock = 0;
        }
    }

    class Venta : Producto
    {
        protected int id_venta;
        protected string comentarios;

        public Venta(int id,string comentario, int id_producto, int stock) : base(id_producto, stock) //La clase Venta hereda de Producto
        {
            this.id_venta = id;
            this.comentarios = comentario;
        }
        public Venta(int id, int id_producto, int stock) : base(id_producto, stock) //La clase Venta hereda de Producto
        {
            this.id_venta = 0;
            this.comentarios = string.Empty;
        }

    }

    class ProductoVendido : Venta
    {
        protected int id_producto_vendido;

        //La clase ProductoVendido hereda de Venta
        public ProductoVendido(int id_producto_vendido, int id_venta, int id_producto, int stock) : base(id_venta, id_producto, stock)
        {
            this.id_producto_vendido = id_producto_vendido;
        }
    }

}