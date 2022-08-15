using Microsoft.AspNetCore.Mvc;
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
    }
}
