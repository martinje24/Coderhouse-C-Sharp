using Microsoft.AspNetCore.Mvc;
using MiPrimeraAPI2.Controllers.DTOS;
using MiPrimeraAPI2.Model;
using MiPrimeraAPI2.Repository;

namespace MiPrimeraAPI2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController
    {
        [HttpGet(Name = "GetProductos")] //Esto es un endpoint
        public List<Producto> GetProductos()
        {
            return ProductoHandler.GetProductos();
        }

        [HttpPost(Name ="PostProductos")]
        public bool CrearProducto([FromBody] PostProducto producto)
        {
            try
            {
                return ProductoHandler.CrearProducto(new Producto
                {
                    descripciones = producto.Descripciones,
                    costo = producto.Costo,
                    precioVenta = producto.PrecioVenta,
                    stock = producto.Stock,
                    id_Usuario = producto.Id_Usuario
                });
                Console.WriteLine(DateTime.Now + " [User created]: " + producto.Descripciones);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        [HttpPut]
        public bool ModificarProducto([FromBody] PutProducto producto)
        {
            return ProductoHandler.ModificarCamposDeProducto(new Producto
            {
                id = producto.Id,
                descripciones = producto.Descripciones,
                stock = producto.Stock,
                precioVenta=producto.PrecioVenta,
                id_Usuario=producto.Id_Usuario,
                costo=producto.Costo
            });
        }


        [HttpDelete]
        public bool EliminarProducto([FromBody] int id)
        {
            try
            {
                return ProductoHandler.EliminarProducto(id);
                Console.WriteLine("User with Id: " + id.ToString() + " successfully deleted!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
