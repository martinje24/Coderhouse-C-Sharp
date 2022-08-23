using Microsoft.AspNetCore.Mvc;
using MiPrimeraAPI2.Controllers.DTOS;
using MiPrimeraAPI2.Model;
using MiPrimeraAPI2.Repository;

namespace MiPrimeraAPI2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VentaController
    {
        [HttpGet(Name = "GetVentas")] //Esto es un endpoint
        public List<Venta> GetVentas()
        {
            return VentaHandler.GetVentas();
        }

        [HttpDelete]
        public bool EliminarVenta([FromBody] int id)
        {
            try
            {
                return VentaHandler.EliminarVenta(id);
                Console.WriteLine("User with Id: " + id.ToString() + " successfully deleted!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        [HttpPost(Name = "PostVenta")]
        public bool CrearVenta([FromBody] PostVenta venta)
        {
            try
            {
                return VentaHandler.CrearVenta(new Venta
                {
                    comentarios = venta.comentarios
                });
                Console.WriteLine(DateTime.Now + " [Venta creada]: " + venta.comentarios);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        [HttpPut(Name = "PutVenta")]
        public bool ModificarVenta([FromBody] PutVenta venta)
        {
            return VentaHandler.ModificarVenta(new Venta
            {
                id = venta.id,
                comentarios = venta.comentarios
            });
        }
    }
}
