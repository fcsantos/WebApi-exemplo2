using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Web.Models
{
    public class AutorModelConsulta
    {
        public int IdAutor { get; set; }
        public string Nome { get; set; }
        public int QtdLivros { get; set; }
    }

    public class AutorModelCadastro
    {        
        public string Nome { get; set; }
    }

    public class AutorModelEdicao
    {
        public int IdAutor { get; set; }
        public string Nome { get; set; }
    }
}
