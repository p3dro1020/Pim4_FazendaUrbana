using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pim4_FazendaUrbana.WEB.Models;

namespace Pim4_FazendaUrbana.WEB.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            LoginModel loginModel = JsonConvert.DeserializeObject<LoginModel>(sessaoUsuario);

            return View(loginModel);
        }
    }
}
