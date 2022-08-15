using Microsoft.AspNetCore.Mvc;
using MiPrimeraAPI2.Model;
using MiPrimeraAPI2.Repository;//Debido a que UsuarioHandler está en la carpeta Repository
//Hay que hacer un Handler por cada tabla

namespace MiPrimeraAPI2.Controllers
{
    [ApiController]//Con esto le indicamos que nuestra clase es un Controller
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    //El controllerBase exponen todas las clases que exponen los métodos HTTPS
    {
        [HttpGet(Name ="GetUsuarios")] //Esto es un endpoint
        public List<Usuario> GetUsuarios()
        {
            return UsuarioHandler.GetUsuarios();
            /*return new List<Usuario>() { new Usuario
            {
                Nombre="Ivan",
                Apellido="Martin",
                Mail="ivan.martin@gmail.com",
                NombreUsuario="iMartin",
                Contraseña="Contraseña"
            }};*/
        }
    }
}
