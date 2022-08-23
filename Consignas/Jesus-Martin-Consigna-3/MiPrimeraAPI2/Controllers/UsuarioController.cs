using Microsoft.AspNetCore.Mvc;
using MiPrimeraAPI2.Controllers.DTOS;
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

        [HttpDelete]
        public bool EliminarUsuario([FromBody] int id)
        {
            try
            {
                return UsuarioHandler.EliminarUsuario(id);
                Console.WriteLine("User with Id: "+id.ToString()+" successfully deleted!");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        [HttpPut]
        public bool ModificarUsuario([FromBody] PutUsuario usuario)
        {
            return UsuarioHandler.ModificarNombreDeUsuario(new Usuario
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido=usuario.Apellido
            });
        }

        [HttpPost]
        public bool CrearUsuario([FromBody] PostUsuario usuario)
        {
                       
            try
            {
                return UsuarioHandler.CrearUsuario(new Usuario
                {
                    Apellido = usuario.Apellido,
                    Contraseña = usuario.Contraseña,
                    Mail = usuario.Mail,
                    Nombre = usuario.Nombre,
                    NombreUsuario = usuario.NombreUsuario
                });
                Console.WriteLine(DateTime.Now + " [User created]: " + usuario.NombreUsuario);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
