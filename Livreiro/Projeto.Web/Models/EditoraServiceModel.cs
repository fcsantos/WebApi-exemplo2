using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Web.Models
{
    public class EditoraModelConsulta
    {
        public int IdEditora { get; set; }
        public string Nome { get; set; }        
    }

    public class EditoraModelCadastro
    {
        public string Nome { get; set; }
    }

    public class EditoraModelEdicao
    {
        public int IdEditora { get; set; }
        public string Nome { get; set; }
    }
}
