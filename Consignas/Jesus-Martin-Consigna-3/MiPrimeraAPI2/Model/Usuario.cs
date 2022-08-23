namespace MiPrimeraAPI2.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Contraseña { get; set; }
        public string NombreUsuario { get; set; }
        public string Mail { get; set; }
        
        public Usuario() //Constructor No Parametrizado
        {
            this.Id = -9999;
            this.Nombre = string.Empty;
            this.Apellido = string.Empty;
            this.Mail = string.Empty;
            this.Contraseña = string.Empty;
            this.NombreUsuario = string.Empty;
        }
        public Usuario(int id_usuario)
        {
            this.Id = id_usuario;
            this.Nombre = string.Empty;
            this.Apellido = string.Empty;
            this.Mail = string.Empty;
            this.Contraseña = string.Empty;
            this.NombreUsuario = string.Empty;
        }
        public Usuario(int id_usuario, string nombre, string apellido, string email, string password, string nombreUsuario)
        {
            this.Id = id_usuario;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Mail = email;
            this.Contraseña = password;
            this.NombreUsuario = nombreUsuario;
        }
    }

}
