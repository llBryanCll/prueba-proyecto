using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoSenaLmour.Models;
using System.Diagnostics;

namespace ProyectoSenaLmour.Controllers
{
    public class HomeController : Controller
    {
        private readonly LmourContext _context;

        public HomeController(LmourContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "administrador")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Ventas()
        {
            return View();
        }
        public IActionResult compras ()
        {
            return View();
        }
        public IActionResult clientes ()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}