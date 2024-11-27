using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pim4_FazendaUrbana.DATA.Models;
using Pim4_FazendaUrbana.DATA.Services;
using Pim4_FazendaUrbana.WEB.Enums;
using Pim4_FazendaUrbana.WEB.Filters;

namespace Pim4_FazendaUrbana.WEB.Controllers
{
    [PaginaSomenteAdmin]
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
            ViewBag.Perfis = Enum.GetValues(typeof(PerfilEnum))
                             .Cast<PerfilEnum>()
                             .Select(p => new SelectListItem
                             {
                                 Value = ((int)p).ToString(),
                                 Text = p.ToString()
                             })
                             .ToList();
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
            
            ViewBag.Perfis = Enum.GetValues(typeof(PerfilEnum))
                         .Cast<PerfilEnum>()
                         .Select(p => new SelectListItem
                         {
                             Value = ((int)p).ToString(),
                             Text = p.ToString()
                         })
                         .ToList();

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
            // verifica se o funcionário foi encontrado
            if (funcionario == null)
            {
                return NotFound();
            }

            ViewBag.Perfis = Enum.GetValues(typeof(PerfilEnum))
                             .Cast<PerfilEnum>()
                             .Select(p => new SelectListItem
                             {
                                 Value = ((int)p).ToString(),
                                 Text = p.ToString(),
                                 Selected = (int)p == (int)funcionario.Perfil // Marcar como selecionado
                             })
                             .ToList();
            return View(funcionario);
        }

        [HttpPost]
        public ActionResult Edit(Funcionario model)
        {
            Funcionario funcionario = _funcionarioService._repositoryFuncionario.Alterar(model);
            if (ModelState.IsValid)
            {                
                int id = funcionario.IdFuncionario;
                return RedirectToAction("Details", new { id });
            }

            ViewBag.Perfis = Enum.GetValues(typeof(PerfilEnum))
                             .Cast<PerfilEnum>()
                             .Select(p => new SelectListItem
                             {
                                 Value = ((int)p).ToString(),
                                 Text = p.ToString(),
                                 Selected = (int)p == (int)funcionario.Perfil
                             })
                             .ToList();
            return View(funcionario);
        }

        public ActionResult Delete(int id)
        {
            _funcionarioService._repositoryFuncionario.Excluir(id);
            return RedirectToAction("Index");
        }

    }
}
