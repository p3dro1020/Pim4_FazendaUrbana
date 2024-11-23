using Microsoft.AspNetCore.Mvc;
using Pim4_FazendaUrbana.DATA.Models;
using Pim4_FazendaUrbana.DATA.Services;
using Pim4_FazendaUrbana.WEB.Filters;

namespace Pim4_FazendaUrbana.WEB.Controllers
{
    [PaginaSomenteAdmin]
    public class ProdutoController : Controller
    {
        private ProdutoService _produtoService = new ProdutoService();

        public IActionResult Index()
        {
            List<Produto> _listProduto= _produtoService._repositoryProduto.SelecionarTodos();
            return View(_listProduto);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Produto model)
        {
            if (ModelState.IsValid)
            {
                _produtoService._repositoryProduto.Incluir(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Details(int id)
        {
            Produto produto = _produtoService._repositoryProduto.SelecionarPk(id);
            return View(produto);
        }

        public ActionResult Edit(int id)
        {
            Produto produto = _produtoService._repositoryProduto.SelecionarPk(id);
            return View(produto);
        }

        [HttpPost]
        public ActionResult Edit(Produto model)
        {
            Produto produto = _produtoService._repositoryProduto.Alterar(model);

            int id = produto.IdProduto;

            return RedirectToAction("Details", new { id });
        }

        public ActionResult Delete(int id) 
        {
            _produtoService._repositoryProduto.Excluir(id);
            return RedirectToAction("Index");
        }

    }
}
