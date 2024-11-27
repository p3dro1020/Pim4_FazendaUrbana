﻿using Microsoft.AspNetCore.Mvc;
using Pim4_FazendaUrbana.DATA.Interfaces;
using Pim4_FazendaUrbana.DATA.Repositories;

namespace Pim4_FazendaUrbana.WEB.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IRepositoryPedido _pedidoRepository;
        private readonly IRepositoryItemPedido _itemPedidoRepository;

        public PedidoController(IRepositoryPedido pedidoRepository, IRepositoryItemPedido itemPedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
            _itemPedidoRepository = itemPedidoRepository;
        }

        public IActionResult Index()
        {
            // Obtém todos os pedidos
            var pedidos = _pedidoRepository.SelecionarTodos();
            return View(pedidos);
        }

        public IActionResult Detalhes(int id)
        {
            // Obtém o pedido pelo ID e inclui os itens relacionados
            var pedido = _pedidoRepository.SelecionarPk(id);

            if (pedido == null)
            {
                return NotFound();
            }

            // Obtém os itens relacionados manualmente (já que RepositoryBase não suporta Include diretamente)
            pedido.Itens = _itemPedidoRepository
                .SelecionarTodos()
                .Where(i => i.IdPedido == id)
                .ToList();

            return PartialView("_DetalhesPedido", pedido);
        }
    }

}