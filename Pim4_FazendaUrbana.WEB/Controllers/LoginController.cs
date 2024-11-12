using Microsoft.AspNetCore.Mvc;
using Pim4_FazendaUrbana.WEB.Models;

namespace Pim4_FazendaUrbana.WEB.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    return RedirectToAction("Index","Home");
                }
                return View("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = "Ops, não conseguimos realizar o seu login"+ ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
