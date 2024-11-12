using Pim4_FazendaUrbana.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pim4_FazendaUrbana.DATA.Services
{
    public class ProdutoService
    {
        public RepositoryProduto _repositoryProduto { get; set; }
        public ProdutoService() 
        {
            _repositoryProduto = new RepositoryProduto();
        }
    }
}
