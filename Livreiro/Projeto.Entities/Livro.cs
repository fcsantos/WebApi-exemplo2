using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entities
{
    public class Livro
    {
        public virtual int IdLivro { get; set; }
        public virtual string ISBN { get; set; }
        public virtual string Titulo { get; set; }
        public virtual string Genero { get; set; }
        public virtual string Sinopse { get; set; }
        public virtual string Categoria { get; set; }
        public virtual int AutorId { get; set; }
        public virtual int EditoraId { get; set; }

        #region Relacionamentos
        public virtual Autor Autor { get; set; }
        public virtual Editora Editora { get; set; }
        #endregion
    }
}
