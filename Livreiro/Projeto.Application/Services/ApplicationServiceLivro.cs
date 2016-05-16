using Projeto.Application.Contracts;
using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Domain.Contracts.Services;

namespace Projeto.Application.Services
{
    public class ApplicationServiceLivro : ApplicationServiceBase<Livro>, IApplicationServiceLivro
    {
        private readonly IDomainServiceLivro dominio;

        public ApplicationServiceLivro(IDomainServiceLivro dominio) : base(dominio)
        {
            this.dominio = dominio;
        }

        public void Cadastrar(Livro l, int AutorId, int EditoraId)
        {
            dominio.Cadastrar(l, AutorId, EditoraId);
        }

        public IList<Livro> ObterPorAutor(int AutorId)
        {
            return dominio.ObterPorAutor(AutorId);
        }

        public IList<Livro> ObterPorEditora(int EditoraId)
        {
            return dominio.ObterPorEditora(EditoraId);
        }
    }
}
