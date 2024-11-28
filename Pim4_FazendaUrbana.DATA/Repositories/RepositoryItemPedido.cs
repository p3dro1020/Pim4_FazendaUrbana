using Pim4_FazendaUrbana.DATA.Interfaces;
using Pim4_FazendaUrbana.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pim4_FazendaUrbana.DATA.Repositories
{
    public class RepositoryItemPedido : RepositoryBase<ItemPedido>, IRepositoryItemPedido
    {
        public RepositoryItemPedido(bool SaveChanges = true) : base(SaveChanges)
        {

        }

        public override List<ItemPedido> SelecionarTodos()
        {
            // Inclui o relacionamento com Produto
            return Query(i => i.Produto).ToList();
        }

    }
}
