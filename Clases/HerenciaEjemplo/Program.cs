namespace EjemploDeClase
{
    class ProbarObjetos
    {
        static void Main(string[] args) //Método público del compilador que no devuelve nada y no se necesita instanciar
        {

            Empleado empleado = new Empleado("AMFK34ds",29307345,"Juan Coderhouse","Nicaragua 2014 Palermo");
            Estudiante estudiante = new Estudiante("Backend",1234586,"Pedro Csharp","Jujuy 2020 Merlo");

            Console.WriteLine(empleado.legajo); //para correr esta línea debemos poner "public" el legajo en vez de "protected"

            Persona persona = new Persona(29307345, "Persona Coderhouse", "Vienda Locohona");
            persona.MostrarDatos();

            //¿Qué pasa si nosotros implementamos MostrarDatos() con estudiante?

            empleado.MostrarDatos(); //en este caso como se sobre escribió, apunta a la clase Empleado
            estudiante.MostrarDatos(); //resulta que se heredó el método de MostrarDatos, apunta a clase Persona

            Console.WriteLine(Persona.TelefonosDeEmergencia());//Aquí ya no es necesario declarar persona
        }
    }

    public interface IEstudiante
    {
        long DevolverDni();
    }

    public class Persona
    {
        //Se usa protected para que se pueda acceder a esta propiedad por la clase Persona
        //o por las clases que estén dentro
        protected long dni;
        protected string nombre;
        protected string domicilioParticular;

        public Persona() //Constructor no parametrizado
        {
            this.dni = 0;
            this.nombre = string.Empty;
            this.domicilioParticular = string.Empty;
        }

        public Persona(long dni, string nombre, string domicilio) //Constructor parametrizado
        {
            this.dni = dni;
            this.nombre = nombre;
            this.domicilioParticular = domicilio;
        }

        public virtual void MostrarDatos()
        {
            Console.WriteLine("DNI: " +dni+"  Nombre: "+nombre+"  Domicilio Particular: "+domicilioParticular);
        }

        public override bool Equals(object? obj)//el signo ? es por si el objeto es nulo aún pueda continuar
        {
            if (obj==null)
            {
                return false;
            }
            //Vamos a forzar a que este objeto sea transformado al tipo persona
            Persona persona = (Persona)obj; //Hacemos un casteo aquí convirtiendo a tipo persona
            return this.dni == persona.dni; //Aquí retorna si el objeto tiene dni
        }

        public static string TelefonosDeEmergencia()
        {
            return "911 - Emergencias";
        }
    }

    //Aquí se heredan las propiedades de la clase persona
    class Empleado : Persona //Se le indica que Empleado implemente lo que tiene la clase Persona
    {
        public string legajo;
        
        //Para poder instanciar la clase Persona en Empleado debemos utilizar su constructor
        public Empleado(string legajo, long dni, string nombre,string domicilio) 
            : base(dni,nombre,domicilio) //Utiliza: Ctrl+Shift+Espacio para acceder a cómo se utiliza los constructores
        {
            this.legajo = legajo;
        }

        //Aquí le vamos a implementar otro significado a MostrarDatos() que heredamos de persona
        public override void MostrarDatos() //es imperante que tenga el virtual en el método MostrarDatos
        {
            base.MostrarDatos(); //nos trae la base de MostrarDatos()
            Console.WriteLine("Legajo: " + legajo);
        }
    }

    class Estudiante : Persona , IEstudiante
    {
        protected string carrera;

        public Estudiante(string carrera, long dni, string nombre, string domicilio)
            : base(dni,nombre,domicilio)
        {
            this.carrera = carrera;
        }

        public long DevolverDni()
        {
            return dni;
        }
    }
}