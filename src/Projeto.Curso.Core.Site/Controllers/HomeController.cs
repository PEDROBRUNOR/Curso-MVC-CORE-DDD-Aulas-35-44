using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Projeto.Curso.Core.Site.Models;

namespace Projeto.Curso.Core.Site.Controllers
{
    public class HomeController : Controller
    {

        [Route("")]
        [Route("Pedidos-Menu-Principal")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
