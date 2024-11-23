using Pim4_FazendaUrbana.WEB.Models;

namespace Pim4_FazendaUrbana.WEB.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(LoginModel usuario);
        void RemoverSessaoDoUsuario();
        LoginModel BuscarSessaoDoUsuario();
    }
}
