using Newtonsoft.Json;
using Pim4_FazendaUrbana.WEB.Models;

namespace Pim4_FazendaUrbana.WEB.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor _httpContextAcessor)
        {
            _httpContext = _httpContextAcessor;
        }

        public LoginModel BuscarSessaoDoUsuario()
        {
            string sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");
            if (string.IsNullOrEmpty(sessaoUsuario)) return null;
            return JsonConvert.DeserializeObject<LoginModel>(sessaoUsuario);
        }

        public void CriarSessaoDoUsuario(LoginModel usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario);
            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
        }

        public void RemoverSessaoDoUsuario()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
