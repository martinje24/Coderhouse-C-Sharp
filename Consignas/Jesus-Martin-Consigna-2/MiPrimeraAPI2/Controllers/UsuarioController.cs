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
        }

        [HttpGet("{nombreUsuario}/{contraseña}")]
        public object Login(string nombreUsuario,string contraseña)
        {//public bool Login(...)
            Usuario usuario= UsuarioHandler.GetUsuarioByContraseña(nombreUsuario, contraseña);
            //return usuario;
            IDictionary<string, string> throwReponse = new Dictionary<string, string>();
            if (usuario.Id == -9999)//null
            {
                throwReponse.Add("error", "Password or User not defined");
                throwReponse.Add("userName", "null");
                throwReponse.Add("userLastName", "null");
                throwReponse.Add("value","false");
                //return false; //if bool
            }
            else
            {
                throwReponse.Add("error", "User finded");
                throwReponse.Add("userName", usuario.Nombre);
                throwReponse.Add("userLastName", usuario.Apellido);
                throwReponse.Add("value", "true");
                //return true; //if bool
            }
            return throwReponse;
        }
    }
}
