using Microsoft.AspNetCore.Mvc;
using Pim4_FazendaUrbana.DATA.Models;
using Pim4_FazendaUrbana.DATA.Services;
using Pim4_FazendaUrbana.WEB.Filters;

namespace Pim4_FazendaUrbana.WEB.Controllers
{
    [PaginaSomenteAdmin]
    public class FornecedorController : Controller
    {
        private FornecedorService _fornecedorService = new FornecedorService();

        public IActionResult Index()
        {
            List<Fornecedor> _listFornecedor = _fornecedorService._repositoryFornecedor.SelecionarTodos();
            return View(_listFornecedor);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Fornecedor model)
        {
            if(ModelState.IsValid)
            {
                _fornecedorService._repositoryFornecedor.Incluir(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Details(int id)
        {
            Fornecedor fornecedor= _fornecedorService._repositoryFornecedor.SelecionarPk(id);
            return View(fornecedor);
        }

        public ActionResult Edit(int id)
        {
            Fornecedor fornecedor = _fornecedorService._repositoryFornecedor.SelecionarPk(id);
            return View(fornecedor);
        }

        [HttpPost]
        public ActionResult Edit(Fornecedor model)
        {
            Fornecedor fornecedor = _fornecedorService._repositoryFornecedor.Alterar(model);

            int id = fornecedor.IdFornecedor;

            return RedirectToAction("Details", new { id });
        }

        public ActionResult Delete(int id)
        {
            _fornecedorService._repositoryFornecedor.Excluir(id);
            return RedirectToAction("Index");
        }

    }
}
