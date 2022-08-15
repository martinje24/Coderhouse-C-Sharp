namespace EjemploDeClase
{
    public class ProbarObjetos
    {
        static void Main(string[] args)
        {
            List<string> nombres = new List<string> { "Roman", "Ana", "Felipe", "Roman" };

            nombres.Remove("Roman");
            int indiceDeRoman = nombres.IndexOf("Roman");
            Console.WriteLine(indiceDeRoman);
            foreach (var nombre in nombres)
            {
                Console.WriteLine($"Hola... {nombre.ToUpper()}");
            }

            ListasMayores mayores = new ListasMayores();
            Cliente[] clientes = //Creamos una lista de Cliente
            {
                new Cliente("Juan Perez",156446,"Av de los corrales",34),
                new Cliente("Pedro Diaz",156447,"Av rivadavia 7689",30),
                new Cliente("Ricardo Lopez",156448,"Av Buenos Aires 3434",18),
                new Cliente("Luis Mejia",156449,"Constitución",34),
                new Cliente("Alberto Fernández",156450,"San Pedro 234",60)
            };            

            //Usar Alt + M después del . en mayores para accesar a los métodos creados
            mayores.InsertarEnLista(clientes);

            mayores.MostrarLista();

            Cliente clienteABorrar = clientes.FirstOrDefault(f => f.ID == 156445);
            if(clienteABorrar != null)
            {
                Console.WriteLine($"\n\tCliente a borrar con Nombre: {clienteABorrar.Nombre}");
            }
            else
            {
                Console.WriteLine("\n\tCliente no encontrado");
            }
            bool result=mayores.BorrarCliente(clienteABorrar);
            Console.WriteLine("\n\n\tSe borro el cliente?: "+result.ToString()+"\n\n"); 
            mayores.MostrarLista();
        }

        public class Cliente
        {
            public string Nombre;
            public long ID;
            public string Direccion;
            public short Edad;
            public Cliente(string nombre, long iD, string direccion, short edad)
            {
                Nombre = nombre;
                ID = iD;
                Direccion = direccion;
                Edad = edad;
            }

        }

        public class ListasMayores
        {
            public List<Cliente> _clientesMayores;

            public ListasMayores()
            {
                _clientesMayores = new List<Cliente>();
            }

            public void InsertarEnLista(Cliente[] clientes)
            {
                Console.WriteLine($"Insertando en lista {clientes.Length} clientes");

                //Uso del AddRange
                //_clientesMayores.Add(clientes);

                foreach (Cliente cliente in clientes)
                {
                    _clientesMayores.Add(cliente);
                }
            }

            public void MostrarLista()
            {
                foreach (Cliente cliente in _clientesMayores)
                {
                    Console.WriteLine($"Nombre: {cliente.Nombre} - ID: {cliente.ID} " +
                        $"- Direccion: {cliente.Direccion} - Edad: {cliente.Edad}");
                }
            }

            public bool BorrarCliente(Cliente cliente)
            {
                bool seBorroElCliente = false;
                if(_clientesMayores.Contains(cliente))
                {
                    seBorroElCliente = _clientesMayores.Remove(cliente);
                }

                return seBorroElCliente;
            }
        }
    }
}
