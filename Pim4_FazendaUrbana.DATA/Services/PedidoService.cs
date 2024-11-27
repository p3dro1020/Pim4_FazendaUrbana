using Pim4_FazendaUrbana.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pim4_FazendaUrbana.DATA.Services
{
    public class PedidoService
    {
        public RepositoryPedido _repositoryPedido { get; set; }

        public PedidoService()
        {
            _repositoryPedido = new RepositoryPedido();
        }

    }
}
