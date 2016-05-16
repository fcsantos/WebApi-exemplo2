using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Infra.Persistence.Configurations
{
    public class LivroConfiguration : EntityTypeConfiguration<Livro>
    {
        public LivroConfiguration()
        {
            HasKey(l => l.IdLivro);

            Property(l => l.ISBN).HasMaxLength(13).IsRequired();
            Property(l => l.Sinopse).HasMaxLength(200).IsRequired();
            Property(l => l.Titulo).HasMaxLength(100).IsRequired();
            Property(l => l.Genero).HasMaxLength(30).IsRequired();
            Property(l => l.Categoria).HasMaxLength(30).IsRequired();

            HasRequired(l => l.Editora).WithMany(e => e.Livros).HasForeignKey(e => e.EditoraId);
            HasRequired(l => l.Autor).WithMany(a => a.Livros).HasForeignKey(e => e.AutorId);
        }
    }
}
