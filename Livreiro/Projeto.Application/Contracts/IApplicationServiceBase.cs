using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Application.Contracts
{
    public interface IApplicationServiceBase<TEntity> where TEntity : class
    {
        void Cadastrar(TEntity obj);
        void Atualizar(TEntity obj);
        void Remover(TEntity obj);

        IList<TEntity> ObterTodos();
        TEntity ObterPorId(int id);
        IQueryable<TEntity> ObterTodosQuery();
        IEnumerable<TEntity> ObterPor(Expression<Func<TEntity, bool>> predicate);
    }
}
