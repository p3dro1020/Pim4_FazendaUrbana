using Pim4_FazendaUrbana.DATA.Interfaces;
using Pim4_FazendaUrbana.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pim4_FazendaUrbana.DATA.Repositories
{
    public class RepositoryFuncionario : RepositoryBase<Funcionario>, IRepositoryFuncionario
    {
        public RepositoryFuncionario() : base()
        {
        }


        public Funcionario BuscarPorLogin(string usuario)
        {
            return _Context.Funcionario.FirstOrDefault(x => x.Usuario.ToUpper() == usuario.ToUpper());
        }
    }
}
