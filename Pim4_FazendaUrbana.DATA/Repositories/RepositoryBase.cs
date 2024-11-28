using Microsoft.EntityFrameworkCore;
using Pim4_FazendaUrbana.DATA.Interfaces;
using Pim4_FazendaUrbana.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pim4_FazendaUrbana.DATA.Repositories
{
    public class RepositoryBase<T> : IRepositoryModel<T>, IDisposable where T : class
    {
        protected PimFazendaUrbanaWebContext _Context;
        public bool _SaveChanges = true;

        public RepositoryBase(bool saveChanges = true)
        {
            _SaveChanges = saveChanges;
            _Context = new PimFazendaUrbanaWebContext();
        }

        public T Alterar(T objeto)
        {
            _Context.Entry(objeto).State = EntityState.Modified;

            if(_SaveChanges)
            {
                _Context.SaveChanges();
            }

            return objeto;
        }

        public void Dispose()
        {
            _Context.Dispose();
        }

        public void Excluir(T objeto)
        {
            _Context.Set<T>().Remove(objeto);

            if (_SaveChanges)
            {
                _Context.SaveChanges();
            }
        }

        public void Excluir(params object[] variavel)
        {
            var obj = SelecionarPk(variavel);
            Excluir(obj);
        }

        public T Incluir(T objeto)
        {
            _Context.Set<T>().Add(objeto);

            if (_SaveChanges)
            {
                _Context.SaveChanges();
            }

            return objeto;
        }

        public IQueryable<T> Query(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _Context.Set<T>();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query;
        }

        public void SaveChanges()
        {
            _Context.SaveChanges();
        }

        public T SelecionarPk(params object[] variavel)
        {
            return _Context.Set<T>().Find(variavel);
        }

        public virtual List<T> SelecionarTodos()
        {
            return _Context.Set<T>().ToList();
        }



    }
}
