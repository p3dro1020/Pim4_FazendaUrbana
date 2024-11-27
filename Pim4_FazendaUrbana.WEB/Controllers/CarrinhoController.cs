using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Pim4_FazendaUrbana.DATA.Interfaces;
using Pim4_FazendaUrbana.DATA.Models;
using Pim4_FazendaUrbana.DATA.Services;
using Pim4_FazendaUrbana.WEB.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Pim4_FazendaUrbana.WEB.Controllers
{
    [PaginaUsuarioLogado]
    public class CarrinhoController : Controller
    {
        private ProdutoService _produtoService = new ProdutoService();
        private static List<CartItem> ItensCarrinho = new List<CartItem>();
        private PedidoService _pedidoService = new PedidoService();
        private ItemPedidoService _itemPedidoService = new ItemPedidoService();


        public IActionResult Index()
        {
            List<Produto> _listProduto = _produtoService._repositoryProduto.SelecionarTodos();
            return View(_listProduto);
        }

        
        [HttpPost]
        public IActionResult AddToCart([FromBody] CartItemDTO item)
        {
            // Crie um novo item de carrinho
            CartItem newItem = new CartItem
            {
                Id = item.ProductId,
                Nome = item.ProductName,
                Preco = item.ProductPrice,
                Quantidade = 1
            };
            // Recupera a lista de itens do carrinho da sessão
            List<CartItem> _listCartItem = new List<CartItem>();

            if (HttpContext.Session.GetString("cart") != null)
            {
                // Deserializa a lista existente do carrinho
                _listCartItem = JsonConvert.DeserializeObject<List<CartItem>>(HttpContext.Session.GetString("cart"));
            }

            // Adiciona o novo item à lista
            _listCartItem.Add(newItem);

            // Serializa a lista de volta para a sessão
            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(_listCartItem));

            // Opcional: Redireciona para uma página de carrinho ou retorna à página de produtos
            return Json(new { success = true });
        }

        public IActionResult Compras()
        {
            List<CartItem> _listCartItem = new List<CartItem>();
            if (HttpContext.Session.GetString("cart") != null)
            {
                _listCartItem = JsonConvert.DeserializeObject<List<CartItem>>(HttpContext.Session.GetString("cart"));
                return View(_listCartItem);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult FinalizarCompra()
        {
            try
            {
                // Recupera os itens do carrinho da sessão
                var cartSession = HttpContext.Session.GetString("cart");
                if (string.IsNullOrEmpty(cartSession))
                {
                    return BadRequest("O carrinho está vazio.");
                }

                // Deserializa os itens do carrinho
                var cartItems = JsonConvert.DeserializeObject<List<CartItem>>(cartSession);

                if (cartItems == null || !cartItems.Any())
                {
                    return BadRequest("Nenhum item no carrinho.");
                }

                // Criar um novo pedido
                var novoPedido = new Pedido
                {
                    DataCompra = DateTime.Now,
                    QtdItem = cartItems.Sum(item => item.Quantidade),
                    ValorTotal = cartItems.Sum(item => item.Preco * item.Quantidade)
                };

                // Salva o pedido no banco de dados
                var pedidoCriado = _pedidoService._repositoryPedido.Incluir(novoPedido);

                // Adicionar itens ao pedido
                foreach (var item in cartItems)
                {
                    var novoItemPedido = new ItemPedido
                    {
                        IdPedido = pedidoCriado.IdPedido,
                        IdProduto = item.Id, // Relacionado ao ID do produto
                        Quantidade = item.Quantidade,
                        
                        ValorUn = item.Preco // Preço unitário do produto
                    };
                    _itemPedidoService._repositoryItemPedido.Incluir(novoItemPedido);
                }

                // Limpa o carrinho na sessão
                HttpContext.Session.Remove("cart");

                return Ok(new { mensagem = "Compra finalizada com sucesso!", pedidoId = pedidoCriado.IdPedido });
            }
            catch (Exception ex)
            {
                // Logar o erro (opcional) e retornar uma resposta de erro
                return StatusCode(500, $"Erro ao finalizar a compra: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult AtualizarQuantidade([FromBody] CartItemDTO itemDto)
        {
            try
            {
                // Verificar se o item recebido é válido
                if (itemDto == null || itemDto.ProductId <= 0 || itemDto.Quantity < 0)
                {
                    return BadRequest(new { success = false, message = "Dados inválidos." });
                }

                // Buscar o carrinho na sessão
                var cartSession = HttpContext.Session.GetString("cart");
                if (string.IsNullOrEmpty(cartSession))
                {
                    return NotFound(new { success = false, message = "Carrinho não encontrado." });
                }

                // Desserializar os itens do carrinho
                var cartItems = JsonConvert.DeserializeObject<List<CartItem>>(cartSession);

                // Encontrar o item no carrinho
                var item = cartItems.FirstOrDefault(i => i.Id == itemDto.ProductId);
                if (item == null)
                {
                    return NotFound(new { success = false, message = "Item não encontrado no carrinho." });
                }

                // Atualizar a quantidade do item
                item.Quantidade = itemDto.Quantity;

                // Re-serializar e salvar o carrinho atualizado na sessão
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cartItems));

                return Ok(new { success = true, message = "Quantidade atualizada com sucesso." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = $"Erro interno: {ex.Message}" });
            }
        }

    }
}

