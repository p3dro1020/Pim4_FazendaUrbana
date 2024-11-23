using Pim4_FazendaUrbana.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pim4_FazendaUrbana.DATA.Interfaces
{
    public interface IRepositoryFuncionario : IRepositoryModel<Funcionario>
    {
        Funcionario BuscarPorLogin(string usuario);
    }
}
