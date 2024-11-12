using Microsoft.AspNetCore.Mvc;

namespace Pim4_FazendaUrbana.WEB.Controllers
{
    public class CarrinhoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Compras()
        {
            return View();
        }
    }
}
