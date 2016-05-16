using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Domain.Contracts.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(TEntity obj);
        IList<TEntity> FindAll();
        TEntity FindById(int id);
        IQueryable<TEntity> GetAllQueryable();
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);

        void BeginTransaction();
        void Commit();
        void Rollback();

    }
}
