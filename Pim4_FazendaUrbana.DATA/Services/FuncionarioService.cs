using Pim4_FazendaUrbana.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pim4_FazendaUrbana.DATA.Services
{
    public class FuncionarioService
    {
        public RepositoryFuncionario _repositoryFuncionario { get; set; }

        public FuncionarioService()
        {
            _repositoryFuncionario = new RepositoryFuncionario();
        }

    }
}
