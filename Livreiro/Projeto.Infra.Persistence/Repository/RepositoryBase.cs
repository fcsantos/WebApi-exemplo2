using Projeto.Domain.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Projeto.Infra.Persistence.Context;
using System.Data.Entity;

namespace Projeto.Infra.Persistence.Repository
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        //atributo para a classe DataContext..
        protected DataContext Con; //acesso interno e por herança..

        //atributo privado para gerenciar as transações..
        private DbContextTransaction Tr; //null..

        public RepositoryBase()
        {
            //inicializar o atributo DataContext..
            Con = new DataContext(); //instanciando..
        }

        public void Insert(TEntity obj)
        {
            Con.Set<TEntity>().Add(obj);
            Con.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            Con.Entry(obj).State = EntityState.Modified;
            Con.SaveChanges();
        }

        public void Delete(TEntity obj)
        {
            Con.Set<TEntity>().Remove(obj);
            Con.SaveChanges();
        }

        public IList<TEntity> FindAll()
        {
            return Con.Set<TEntity>().ToList();
        }

        public TEntity FindById(int Id)
        {
            return Con.Set<TEntity>().Find(Id);
        }

        public IQueryable<TEntity> GetAllQueryable()
        {
            return Con.Set<TEntity>().AsQueryable<TEntity>();
        }

        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            IEnumerable<TEntity> query = Con.Set<TEntity>().Where(predicate).AsEnumerable();
            return query;
        }

        public void BeginTransaction()
        {
            //iniciando uma transação..
            Tr = Con.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (Tr != null)
                Tr.Commit(); //finalizar
        }

        public void Rollback()
        {
            if (Tr != null)
                Tr.Rollback(); //desfazer
        }
    }
}
