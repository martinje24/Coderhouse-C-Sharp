namespace EjemploDeClase
{
    public class ProbarObjetos
    {
        static void Main(string[] args)
        {
            string[] razasDePerrosArray = new string[5];
            razasDePerrosArray[0] = "Bulldog";
            razasDePerrosArray[1] = "Husky";
            razasDePerrosArray[2] = "Pastor Aleman";
            razasDePerrosArray[3] = "Doberman";
            razasDePerrosArray[4] = "Pitbull";


            string[] razasDePerrosArray2 = {"Chihuaha","Mallinois","Siberiano",
            "Pug","Akita","Rotwiller"};
            Console.WriteLine("\n\tUsando For");
            for (int i = 0; i < razasDePerrosArray.Length; i++)
            {
                Console.WriteLine(razasDePerrosArray[i]);
            }
            Console.WriteLine("\n\tUsando Foreach");
            foreach (string raza in razasDePerrosArray2)
            {
                Console.WriteLine(raza);
            }

            //ejemplo de arrays

            Producto[] bebidasGaseosas = {
                new Producto(1,"Coca-cola", 23, 32, "Gaseosa"),
                new Producto(2,"7UP", 26, 31, "Gaseosa"),
                new Producto(3,"Manaos-cola", 24, 17, "Gaseosa"),
                new Producto(4,"Paso de los toros", 25, 30, "Gaseosa"),
            };

            Producto bebidaMasCara = new Producto();

            foreach (Producto bebida in bebidasGaseosas)
            {
                if (bebida.PrecioDeCompra > bebidaMasCara.PrecioDeCompra)
                {
                    bebidaMasCara = bebida;
                }
            }

            Console.WriteLine("\n\tLa bebida comprada mas cara es:{0}", bebidaMasCara.Descripcion);


            Dictionary<string, string> ciudadXPaises = new Dictionary<string, string>();
            ciudadXPaises.Add("Bogota","Colombia");
            ciudadXPaises.Add("Lima", "Bolivia");
            ciudadXPaises.Add("Buenos Aires", "Argentina");
            ciudadXPaises.Add("Asunción", "Paraguay");
            ciudadXPaises.Add("Montevideo", "Uruguay");

            Console.WriteLine("\n\tLas ciudades por países antes del uso de propiedades son: ");

            foreach (KeyValuePair<string, string> ciudadYPais in ciudadXPaises)
            {
                Console.WriteLine("{0} - {1}",ciudadYPais.Key,ciudadYPais.Value);
            }

            Console.WriteLine("\n\tLas ciudades por países después del uso de propiedades son: ");
            ciudadXPaises.Remove("Buenos Aires"); //elimina
            ciudadXPaises["Lima"] = "Peru"; //cambia

            foreach (KeyValuePair<string, string> ciudadYPais in ciudadXPaises)
            {
                Console.WriteLine("{0} - {1}", ciudadYPais.Key, ciudadYPais.Value);
            }

            if(ciudadXPaises.ContainsKey("Lima"))
            {
                string pais = ciudadXPaises["Lima"];
                Console.WriteLine("\nEl país guardado es: "+pais);
            }



            //Dicionario dentro de diccionario
            Console.WriteLine("\n\n\n\n===== Diccionario dentro de un diccionario =====");

            Dictionary<string, Dictionary<string, double>> catalogoPetShop
                = new Dictionary<string, Dictionary<string, double>>();

            catalogoPetShop.Add("Alimentos para Gatos Cachorro", new Dictionary<string, double>
            {
                {"Cat show",90},
                {"Whiskas   ",85},
                {"Pedigree",95}
            });
            catalogoPetShop.Add("Alimentos para Perro Cachorros", new Dictionary<string, double>
            {
                {"Dow chow",120},
                {"Pro plan",68},
                {"Pedigree",91}
            });
            catalogoPetShop.Add("Alimentos para Perro Adultos", new Dictionary<string, double>
            {
                {"Dow chow",84},
                {"Pro plan",81},
                {"Pedigree",93}
            });

            Console.WriteLine("Sección\t\t\t\t\tProducto\t\tPrecio");
            foreach(KeyValuePair<string,Dictionary<string,double>> seccion in catalogoPetShop)
            {
                Console.WriteLine("{0}",seccion.Key);
                foreach(KeyValuePair<string,double> productoYPrecio in seccion.Value)
                {
                    Console.WriteLine("\t\t\t\t\t{0}\t\t{1}", productoYPrecio.Key,productoYPrecio.Value);
                }
            }

            /*
            Console.WriteLine("\n\n\n\t====== TRY & CATCH =====");
            //Bloque try catch
            try
            {
                int numero = Convert.ToInt32(Console.ReadLine());
                decimal division = 25 / numero;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            int numeroFueraDelTry = Convert.ToInt32(Console.ReadLine());
            decimal divisionFueraDelTry = 25 / numeroFueraDelTry;
            Console.WriteLine(divisionFueraDelTry);
            */


            Console.WriteLine("\n\n\n\n===== Diccionario dentro de un diccionario con array =====");
            Dictionary<string, Dictionary<string, double[]>> menuPorSecciones
                = new Dictionary<string, Dictionary<string, double[]>>();

            menuPorSecciones.Add("Del Horno", new Dictionary<string, double[]>
            {
                {"Baked Lasagna     ",new double [] { 10.45, 12.85 } },
                {"Baked Rigatoni    ",new double [] { 10.45, 12.85 } },
                {"Baked Ravioli     ",new double [] { 10.45, 12.85 } },
                {"Canelloni         ",new double [] { 10.45, 12.85 } },
                {"Manicotti         ",new double [] { 10.45, 12.85 } },
                {"Veal Parmigiana   ",new double [] { 10.95, 13.35 } },
                {"Chicken Parmigiana",new double [] { 10.95, 13.35 } },
                {"Eggplant Parmigiana",new double [] { 10.95, 13.35 } }

            });
            menuPorSecciones.Add("Especialidades de la Casa", new Dictionary<string, double[]>
            {
                {"Veal Scaloppini       ",new double [] { 12.45, 14.85 } },
                {"Chicken with Fettucine",new double [] { 12.45, 14.85 } },
                {"Chicken Cacciatore    ",new double [] { 12.45, 14.85 } },
                {"Deep Fried Shrimp     ",new double [] { 12.45, 14.85 } },
                {"Hamburger Steak       ",new double [] { 12.45, 14.85 } }

            });
            Console.WriteLine("Sección\t\t\t\t\tProducto\t\t\t\tA la Carte\tDinner");
            foreach (KeyValuePair<string, Dictionary<string, double[]>> seccion in menuPorSecciones)
            {
                Console.WriteLine("{0}", seccion.Key);
                foreach (KeyValuePair<string, double[]> productoYPrecio in seccion.Value)
                {
                    Console.WriteLine("\t\t\t\t\t{0}\t\t\t{1}\t\t{2}", productoYPrecio.Key, productoYPrecio.Value[0], productoYPrecio.Value[1]);
                }
            }
        }

    }

    public class Producto
    {
        // sin getters o setters

        public int Codigo;
        public string Descripcion;
        public double PrecioDeCompra;
        public double PrecioDeVenta;
        public string Categoria;

        public Producto()
        {
            Codigo = 0;
            Descripcion = String.Empty;
            PrecioDeCompra = 0;
            PrecioDeVenta = 0;
            Categoria = String.Empty;
        }

        public Producto(int codigo, string descripcion, double precioDeCompra, double precioDeVenta, string categoria)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            PrecioDeCompra = precioDeCompra;
            PrecioDeVenta = precioDeVenta;
            Categoria = categoria;
        }
    }
}


