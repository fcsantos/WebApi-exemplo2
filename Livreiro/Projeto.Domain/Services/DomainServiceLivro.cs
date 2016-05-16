using Projeto.Domain.Contracts.Services;
using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Domain.Contracts.Repository;

namespace Projeto.Domain.Services
{
    public class DomainServiceLivro : DomainServiceBase<Livro>, IDomainServiceLivro
    {
        private readonly IRepositoryLivro repositorio;

        public DomainServiceLivro(IRepositoryLivro repositorio) : base(repositorio)
        {
            this.repositorio = repositorio;
        }

        public void Cadastrar(Livro l, int AutorId, int EditoraId)
        {
            try
            {
                repositorio.BeginTransaction();
                repositorio.Insert(l, AutorId, EditoraId);
                repositorio.Commit();
            }
            catch (Exception e)
            {
                repositorio.Rollback();
                throw new Exception(e.Message);                
            }
        }

        public IList<Livro> ObterPorAutor(int AutorId)
        {
            try
            {
                if (AutorId != 0)
                {
                    return repositorio.FindAllByAutor(AutorId);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IList<Livro> ObterPorEditora(int EditoraId)
        {
            try
            {
                if (EditoraId != 0)
                {
                    return repositorio.FindAllByEditora(EditoraId);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);                
            }
        }
    }
}
