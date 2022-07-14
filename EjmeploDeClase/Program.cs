namespace EjemploDeClase //namespace sirve para agrupar las clases que tiene que ver con lo mismo
{

    class ProbarObjetos
    {
        static void Main(string[] args)
        {
            Console.WriteLine("asd");
            Producto productoPorDefecto = new Producto();//Aquí se instacia la clase producto
            Producto productoPorConstruccion = new Producto(45, "Hola Soy un Producto",
                200, 300, "Categoria de Producto");
            Console.WriteLine(productoPorDefecto._codigo);
            Console.WriteLine(productoPorConstruccion._codigo);
            Console.WriteLine(productoPorConstruccion.ObtenerDescripcion());
            Console.WriteLine(productoPorConstruccion.HayPrecioDeVenta());
            Console.WriteLine("Ejemplo de Getters y Setters");
            productoPorDefecto.Numero_Codigo = 123;
            Console.WriteLine(productoPorDefecto.Numero_Codigo);

            //Ejemplo de clase
            Console.WriteLine("\n\n\t==== Otro ejemplo: ====");
            Usuario usuario=new Usuario(); //Instanciando la clase Usuario
            Console.WriteLine(usuario.DondeVive());
            usuario.SetNewDomicilio("Otro nuevo domicilio 123");
            Console.WriteLine(usuario.DondeVive());

        }
    }
    public class Producto
    {
        //Getters y Setters
        public int Numero_Codigo
        {
            get
            {
                return this._codigo;
            }
            set
            {
                this._codigo = value;
            }
        }

        private string Descripcion
        {
            get
            {
                return this._descripcion;
            }
            set
            {
                this._descripcion = value;
            }
        }


        public int _codigo;
        private string _descripcion;
        private double _precioDeCompra;
        private double _precioDeVenta;
        private string _categoria;
        private bool _estaVencido;
        public Producto() //Este es el constructor
        {
            _codigo=0;
            _descripcion=String.Empty;
            _precioDeCompra = 0;
            _precioDeVenta = 0;
            _categoria=String.Empty;
            _estaVencido=false;
        }
        
        public Producto(int codigo, string descripcion, double precioDeCompra, double precioDeVenta,string categoria)
        {
            this._codigo = codigo;
            this._descripcion = descripcion;
            this._precioDeCompra = precioDeCompra;
            this._precioDeVenta = precioDeVenta;
            this._categoria = categoria;
            this._estaVencido = true;
        }

        public string ObtenerDescripcion() //Método público
        {
            return _descripcion;
        }

        public bool HayPrecioDeVenta() // Crear método booleano para devolver true or false si hay precio
        {
            return this._precioDeVenta > 0;
        }
    }

    public class Usuario
    {
        private string _nombre;
        private string _apellido;
        private int _dni;
        private string _email;
        private int _edad;
        private string _domicilio;
        // Ctrl + . => Hace un constructor después de inicializar las variables
        public Usuario() //Este es el constructor creado de manera manual
        {
            _nombre = String.Empty;
            _apellido = String.Empty;
            _dni = 0;
            _email = String.Empty;
            _edad = 0;
            _domicilio = "Domicilio Falso";
        }
        public string DondeVive()
        {
            return _domicilio;
        }
        public int GetDni()
        {
            return _dni;
        }
        public void SetNewDomicilio(string nuevoDomicilio)
        {
            _domicilio= nuevoDomicilio;
        }

    }

    
}