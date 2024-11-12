using Microsoft.AspNetCore.Mvc;
using Pim4_FazendaUrbana.DATA.Models;
using Pim4_FazendaUrbana.DATA.Services;

namespace Pim4_FazendaUrbana.WEB.Controllers
{
    public class FuncionarioController : Controller
    {
        private FuncionarioService _funcionarioService = new FuncionarioService();

        public IActionResult Index()
        {
            List<Funcionario> _listFuncionario = _funcionarioService._repositoryFuncionario.SelecionarTodos();
            return View(_listFuncionario);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Funcionario model)
        {
            if (ModelState.IsValid)
            {
                _funcionarioService._repositoryFuncionario.Incluir(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Details(int id)
        {
            Funcionario funcionario = _funcionarioService._repositoryFuncionario.SelecionarPk(id);
            return View(funcionario);
        }

        public ActionResult Edit(int id) 
        {
            Funcionario funcionario = _funcionarioService._repositoryFuncionario.SelecionarPk(id);
            return View(funcionario);
        }

        [HttpPost]
        public ActionResult Edit(Funcionario model)
        {
            Funcionario funcionario = _funcionarioService._repositoryFuncionario.Alterar(model);

            int id = funcionario.IdFuncionario;

            return RedirectToAction("Details", new { id });
        }

        public ActionResult Delete(int id)
        {
            _funcionarioService._repositoryFuncionario.Excluir(id);
            return RedirectToAction("Index");
        }

    }
}
