using Projeto.Domain.Contracts.Repository;
using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Infra.Persistence.Repository
{
    public class RepositoryLivro : RepositoryBase<Livro>, IRepositoryLivro
    {
        public void Insert(Livro l, int AutorId, int EditoraId)
        {
            l.Autor = Con.Autor.Find(AutorId);
            l.Editora = Con.Editora.Find(EditoraId);

            Con.Livro.Add(l);
            Con.SaveChanges();
        }

        public IList<Livro> FindAllByAutor(int AutorId)
        {
            return Con.Livro.Where(l => l.AutorId == AutorId).ToList();
        }

        public IList<Livro> FindAllByEditora(int EditoraId)
        {
            return Con.Livro.Where(l => l.EditoraId == EditoraId).ToList();
        }
    }
}
