using Projeto.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Projeto.Domain.Contracts.Services;

namespace Projeto.Application.Services
{
    public abstract class ApplicationServiceBase<TEntity> : IApplicationServiceBase<TEntity> where TEntity : class
    {
        private readonly IDomainServiceBase<TEntity> dominio;

        public ApplicationServiceBase(IDomainServiceBase<TEntity> dominio)
        {
            this.dominio = dominio;
        }

        public void Cadastrar(TEntity obj)
        {
            dominio.Cadastrar(obj);
        }

        public void Atualizar(TEntity obj)
        {
            dominio.Atualizar(obj);
        }

        public void Remover(TEntity obj)
        {
            dominio.Remover(obj);
        }

        public IList<TEntity> ObterTodos()
        {
            return dominio.ObterTodos();
        }

        public TEntity ObterPorId(int id)
        {
            return dominio.ObterPorId(id);
        }

        public IQueryable<TEntity> ObterTodosQuery()
        {
            return dominio.ObterTodosQuery();
        }

        public IEnumerable<TEntity> ObterPor(Expression<Func<TEntity, bool>> predicate)
        {
            return dominio.ObterPor(predicate);
        }
    }
}
