
/*
 * 
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
string nombre ="Ivan";
string apellido = "Martín";
string DNI = "31131392-5";
int edad = 27;
decimal altura = 1.70M;
Console.WriteLine("Hola, mi nombre es: "+ nombre + " " + apellido);
Console.WriteLine("El DNI es: "+ DNI);
Console.WriteLine("Tengo "+edad+" años y mido "+altura.ToString()+" [m]");


Console.WriteLine("Ingrese el primer número");
string value = Console.ReadLine();
Console.WriteLine("Ingrese el segundo número");
string secondValue = Console.ReadLine();
int parsedNumber = Convert.ToInt32(value);
int parsedNumber2 = Convert.ToInt32(secondValue);
int result = parsedNumber + parsedNumber2;
Console.WriteLine("El resultado es: "+result);


// Funciones
int sumando1 = int.Parse(Console.ReadLine());
int sumando2 = int.Parse(Console.ReadLine());
int resultadoDeSumar = Sumar(sumando1, sumando2);
Console.WriteLine(resultadoDeSumar);
int Sumar(int numero1, int numero2)
{
    return numero1 + numero1;
}

void Saludar()
{
    Console.WriteLine("Hola, soy una función saludando");
}
*/


// ======================== EJERCICIO =======================
const string storePassword = "Contraseña";

Console.WriteLine("Validando Acceso");
Login();



void Login()
{
    int contadorDeIntentos = 0;
    bool loginExistoso = false;
    do
    {
        Console.WriteLine("Por favor ingrese su contraseña: ");
        string password = Convert.ToString(Console.ReadLine());
        if (storePassword == password)
        {
            loginExistoso = true;
        }
        else
        {
            Console.WriteLine("Password incorrecta, reinicie la aplicación: ");
        }
        contadorDeIntentos++;
        if(contadorDeIntentos == 5)
        {
            break;
        }
    }

    while (loginExistoso is false);

    if (loginExistoso)
    {
        string mensaje = ContadorDeCaracteres();
        Console.WriteLine("Bienvenido a la aplicación");
        Console.WriteLine("La contraseña " + mensaje+" es correcta");
    }
    else
    {
        Console.WriteLine("No se ha podido loggear");
    }
    
}

string ContadorDeCaracteres()
{
    string resultado = String.Empty;
    for (int i = 1; i < storePassword.Length; i++)
    {
        resultado += "*";
    }
    return resultado;
}




