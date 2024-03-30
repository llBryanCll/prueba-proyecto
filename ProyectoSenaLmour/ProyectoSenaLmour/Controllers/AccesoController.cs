using Microsoft.AspNetCore.Mvc;

using ProyectoSenaLmour.Models;
using ProyectoSenaLmour.Data;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Net.Mail;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace ProyectoSenaLmour.Controllers
{
    public class AccesoController : Controller
    {
        public IActionResult Index()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Index(UsuarioF _usuarioF)
        {
            Da_logica _da_usuarioF = new Da_logica();

            var usuarioF = _da_usuarioF.ValidarUsuarioF(_usuarioF.Correo, _usuarioF.Contraseña);

            if (usuarioF != null)
            {
                var claims = new List<Claim> {
                 new Claim(ClaimTypes.Name, usuarioF.Nombre),
                 new Claim("Correo", usuarioF.Correo)
                 };


                foreach (string rol in usuarioF.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, rol));
                }

                var ClaimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);


                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(ClaimsIdentity));



                return RedirectToAction("Index", "Home");
            }
            else
            {

                return View();
            }

        }

        public async Task<IActionResult> Salir()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "acceso");

        }


        //prueba

     



    }
}

