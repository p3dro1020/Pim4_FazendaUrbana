using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Pim4_FazendaUrbana.WEB.Models;

namespace Pim4_FazendaUrbana.WEB.Filters
{
    public class PaginaUsuarioLogado : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string sessaoUsuario = context.HttpContext.Session.GetString("sessaoUsuarioLogado");
            
            if(string.IsNullOrEmpty(sessaoUsuario))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { {"controller", "Login" }, {"action", "Index" } });
            }else
            {
                LoginModel login = JsonConvert.DeserializeObject<LoginModel>(sessaoUsuario);

                if(login == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                }

            }

            base.OnActionExecuting(context);
        }
    }
}
