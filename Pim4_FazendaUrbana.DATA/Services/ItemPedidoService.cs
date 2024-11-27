using Pim4_FazendaUrbana.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pim4_FazendaUrbana.DATA.Services
{
    public class ItemPedidoService
    {
        public RepositoryItemPedido _repositoryItemPedido { get; set; }

        public ItemPedidoService()
        {
            _repositoryItemPedido = new RepositoryItemPedido();
        }
    }
}
