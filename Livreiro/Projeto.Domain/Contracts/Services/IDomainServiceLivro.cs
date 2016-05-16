using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Domain.Contracts.Services
{
    public interface IDomainServiceLivro : IDomainServiceBase<Livro>
    {
        void Cadastrar(Livro l, int AutorId, int EditoraId);

        IList<Livro> ObterPorAutor(int AutorId);

        IList<Livro> ObterPorEditora(int EditoraId);
    }
}
