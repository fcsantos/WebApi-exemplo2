using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Domain.Contracts.Repository
{
    public interface IRepositoryLivro : IRepositoryBase<Livro>
    {
        void Insert(Livro l, int AutorId, int EditoraId);

        IList<Livro> FindAllByAutor(int AutorId);

        IList<Livro> FindAllByEditora(int EditoraId);
    }
}
