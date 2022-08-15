using Microsoft.AspNetCore.Mvc;
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
    }
}
