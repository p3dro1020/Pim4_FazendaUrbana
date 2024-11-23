using Microsoft.AspNetCore.Mvc;
using Pim4_FazendaUrbana.DATA.Models;
using Pim4_FazendaUrbana.DATA.Services;
using Pim4_FazendaUrbana.WEB.Filters;

namespace Pim4_FazendaUrbana.WEB.Controllers
{
    [PaginaSomenteAdmin]
    public class PlantacaoController : Controller
    {
        private PlantacaoService _plantacaoService = new PlantacaoService();

        public IActionResult Index()
        {
            List<Plantacao> _listPlantacao= _plantacaoService._repositoryPlantacao.SelecionarTodos();
            return View(_listPlantacao);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Plantacao model)
        {
            if (ModelState.IsValid)
            {
                _plantacaoService._repositoryPlantacao.Incluir(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Details(int id)
        {
            Plantacao plantacao = _plantacaoService._repositoryPlantacao.SelecionarPk(id);
            return View(plantacao);
        }

        public ActionResult Edit(int id)
        {
            Plantacao plantacao = _plantacaoService._repositoryPlantacao.SelecionarPk(id);
            return View(plantacao);
        }

        [HttpPost]
        public ActionResult Edit(Plantacao model)
        {
            Plantacao plantacao = _plantacaoService._repositoryPlantacao.Alterar(model);

            int id = plantacao.IdPlantio;

            return RedirectToAction("Details", new { id });
        }

        public IActionResult Delete(int id)
        {
            _plantacaoService._repositoryPlantacao.Excluir(id);
            return RedirectToAction("Index");
        }

    }
}
