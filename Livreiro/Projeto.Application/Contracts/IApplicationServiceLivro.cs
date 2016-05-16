using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Application.Contracts
{
    public interface IApplicationServiceLivro : IApplicationServiceBase<Livro>
    {
        void Cadastrar(Livro l, int AutorId, int EditoraId);

        IList<Livro> ObterPorAutor(int AutorId);

        IList<Livro> ObterPorEditora(int EditoraId);
    }
}
