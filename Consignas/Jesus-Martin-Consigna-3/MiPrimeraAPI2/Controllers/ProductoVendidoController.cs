using Microsoft.AspNetCore.Mvc;
using MiPrimeraAPI2.Model;
using MiPrimeraAPI2.Repository;

namespace MiPrimeraAPI2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoVendidoController
    {
        [HttpGet(Name = "GetProductosVendidos")] //Esto es un endpoint
        public List<ProductoVendido> GetProductosVendidos()
        {
            return ProductoVendidoHandler.GetProductosVendidos();
        }
    }
}
