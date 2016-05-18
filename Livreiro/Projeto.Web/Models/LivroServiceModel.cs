using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Web.Models
{
    public class LivroModelConsulta
    {
        public int IdLivro { get; set; }
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public string Sinopse { get; set; }
        public string Categoria { get; set; }
        public int AutorId { get; set; }
        public string NomeAutor { get; set; }
        public int EditoraId { get; set; }
        public string NomeEditora { get; set; }
    }

    public class LivroModelCadastro
    {
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public string Sinopse { get; set; }
        public string Categoria { get; set; }
        public int AutorId { get; set; }        
        public int EditoraId { get; set; }        
    }

    public class LivroModelEdicao
    {
        public int IdLivro { get; set; }
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public string Sinopse { get; set; }
        public string Categoria { get; set; }
        public int AutorId { get; set; }
        public int EditoraId { get; set; }
    }

    public class LivroModelFiltroPorAutor
    {
        public int AutorId { get; set; }        
    }

    public class LivroModelFiltroPorEditora
    {        
        public int EditoraId { get; set; }
    }
}
