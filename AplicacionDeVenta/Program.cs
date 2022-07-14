//Código de primera clase de C#
Console.WriteLine("=====================================");
Console.WriteLine("Bienvenidos a la aplicación de ventas");
Console.WriteLine("=====================================\n");

string finalizar="Y";
int suma = 0;
do
{
    Console.WriteLine("Ingrese el código del producto: ");
    string codigoDelProducto = Convert.ToString(Console.ReadLine());
    int precioTotal = ValidarCodigoIngresado(codigoDelProducto);
    if (precioTotal != 0)
    {
        suma = +precioTotal;
    }
    Console.WriteLine("Desea comprar algo más (Y/N): ");
    finalizar = Convert.ToString(Console.ReadLine());
    Console.WriteLine("El carrito lleva: " + Convert.ToString(suma));
    if (finalizar == "N")
    {
        Console.WriteLine("La cuenta total es de: " + Convert.ToString(suma));
    }
}
while (finalizar != "N");


Console.WriteLine("Muchas gracias por su compra");

// INICIO DE FUNCIONES

int ValidarCodigoIngresado(string codigoDelProducto)
{
    int cantidadProducto;
    int total;
    if (codigoDelProducto=="DES")
    {
        Console.WriteLine("Ingrese la cantidad del producto");
        cantidadProducto = Convert.ToInt32(Console.ReadLine());
        total = 200 * cantidadProducto; //Multiplicamos el precio del item * cantidadProducto
    }
    else if (codigoDelProducto == "JP")
    {
        Console.WriteLine("Ingrese la cantidad del producto");
        cantidadProducto = Convert.ToInt32(Console.ReadLine());
        total = 300 * cantidadProducto;
    }
    else if (codigoDelProducto == "DET")
    {
        Console.WriteLine("Ingrese la cantidad del producto");
        cantidadProducto = Convert.ToInt32(Console.ReadLine());
        total = 250 * cantidadProducto;
    }
    else
    {
        Console.WriteLine("Se ha ingresado mal el código");
        total = 0;
    }
    /*
    switch (codigoDelProducto)
    {
        case "DES":
            Console.WriteLine("Ingrese la cantidad del producto");
            cantidadProducto=Convert.ToInt32(Console.ReadLine());
            total = 200 * cantidadProducto; //Multiplicamos el precio del item * cantidadProducto
            break;
        case "JP":
            Console.WriteLine("Ingrese la cantidad del producto");
            cantidadProducto = Convert.ToInt32(Console.ReadLine());
            total = 300 * cantidadProducto;
            break;
        case "DET":
            Console.WriteLine("Ingrese la cantidad del producto");
            cantidadProducto = Convert.ToInt32(Console.ReadLine());
            total = 250 * cantidadProducto;
            break;
        default:
            Console.WriteLine("Se ha ingresado mal el código");
            total = 0;
            break;
    }
    */
    return total;
    
}