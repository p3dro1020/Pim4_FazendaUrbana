using Microsoft.AspNetCore.Mvc;
using Pim4_FazendaUrbana.WEB.Filters;

namespace Pim4_FazendaUrbana.WEB.Controllers
{
    [PaginaUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
