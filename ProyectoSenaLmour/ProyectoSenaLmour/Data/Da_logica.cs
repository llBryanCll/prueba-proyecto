using ProyectoSenaLmour.Models;
using System.ComponentModel;
namespace ProyectoSenaLmour.Data
{
    public class Da_logica
    {
        public List<UsuarioF> ListaUsuarioF()
        {
            return new List<UsuarioF>
            {
                new UsuarioF { Nombre = "Marlon", Correo = "administrador@gmail.com", Contraseña = "123", Roles = new string[] { "administrador" } },
                new UsuarioF { Nombre = "Mafe", Correo = "cliente1@gmail.com", Contraseña = "124", Roles = new string[] { "cliente" } },
                new UsuarioF { Nombre = "brayan", Correo = "cliente2@gmail.com", Contraseña = "143", Roles = new string[] { "cliente" } },
                new UsuarioF { Nombre = "Ana", Correo = "cliente3@gmail.com", Contraseña = "113", Roles = new string[] { "cliente" } }





            };
        }

        public UsuarioF ValidarUsuarioF(string _correo, string _contraseña)
        {
            return ListaUsuarioF().Where(item => item.Correo == _correo && item.Contraseña == _contraseña).FirstOrDefault();


        }


    }
}
