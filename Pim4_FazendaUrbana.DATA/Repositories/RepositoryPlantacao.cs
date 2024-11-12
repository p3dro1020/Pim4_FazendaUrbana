using Pim4_FazendaUrbana.DATA.Interfaces;
using Pim4_FazendaUrbana.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pim4_FazendaUrbana.DATA.Repositories
{
    public class RepositoryPlantacao : RepositoryBase<Plantacao>, IRepositoryPlantacao
    {
        public RepositoryPlantacao(bool SaveChanges = true) : base(SaveChanges)
        {
        }
    }
}
