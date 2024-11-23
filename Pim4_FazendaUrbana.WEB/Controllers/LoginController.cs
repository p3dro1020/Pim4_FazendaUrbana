using Microsoft.AspNetCore.Mvc;
using Pim4_FazendaUrbana.DATA.Interfaces;
using Pim4_FazendaUrbana.DATA.Models;
using Pim4_FazendaUrbana.WEB.Helper;
using Pim4_FazendaUrbana.WEB.Models;

namespace Pim4_FazendaUrbana.WEB.Controllers
{
    public class LoginController : Controller
    {
        private readonly IRepositoryFuncionario _repositoryFuncionario;
        private readonly ISessao _sessao;
        public LoginController(IRepositoryFuncionario repositoryFuncionario, ISessao sessao)
        {
            _repositoryFuncionario = repositoryFuncionario;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            // verifica se o usuário está logado, se sim, redireciona para a página inicial
            if (_sessao.BuscarSessaoDoUsuario() != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoDoUsuario();
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    Funcionario funcionario = _repositoryFuncionario.BuscarPorLogin(loginModel.Login);
                    if(funcionario != null)
                    {
                        if(funcionario.SenhaValida(loginModel.Senha))
                        {
                            loginModel.Perfil = funcionario.Perfil;                     
                            _sessao.CriarSessaoDoUsuario(loginModel);
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensagemErro"] = "Ops, não conseguimos validar sua senha, tente novamente";
                    }
                    TempData["MensagemErro"] = "Ops, não conseguimos validar seu usuário e senha, tente novamente";
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
