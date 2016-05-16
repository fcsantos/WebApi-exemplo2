using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Contracts.Repository;

namespace Projeto.Domain.Services
{
    public abstract class DomainServiceBase<TEntity> : IDomainServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> repositorio; //abstração

        public DomainServiceBase(IRepositoryBase<TEntity> repositorio)
        {
            this.repositorio = repositorio;
        }

        public virtual void Cadastrar(TEntity obj)
        {
            try
            {
                repositorio.BeginTransaction();
                repositorio.Insert(obj);
                repositorio.Commit();
            }
            catch (Exception e)
            {
                repositorio.Rollback();
                throw new Exception(e.Message);
            }
        }

        public virtual void Atualizar(TEntity obj)
        {
            try
            {
                repositorio.BeginTransaction();
                repositorio.Update(obj);
                repositorio.Commit();
            }
            catch (Exception e)
            {
                repositorio.Rollback();
                throw new Exception(e.Message);
            }
        }

        public virtual void Remover(TEntity obj)
        {
            try
            {
                repositorio.BeginTransaction();
                repositorio.Delete(obj);
                repositorio.Commit();
            }
            catch (Exception e)
            {
                repositorio.Rollback();
                throw new Exception(e.Message);
            }
        }

        public virtual IList<TEntity> ObterTodos()
        {
            try
            {
                return repositorio.FindAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); 
            }
        }

        public virtual TEntity ObterPorId(int Id)
        {
            try
            {
                return repositorio.FindById(Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public virtual IQueryable<TEntity> ObterTodosQuery()
        {
            try
            {
                return repositorio.GetAllQueryable();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public virtual IEnumerable<TEntity> ObterPor(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return repositorio.FindBy(predicate);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
