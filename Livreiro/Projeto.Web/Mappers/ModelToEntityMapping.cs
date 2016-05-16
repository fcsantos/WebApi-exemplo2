using AutoMapper;
using Projeto.Entities;
using Projeto.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Web.Mappers
{
    public class ModelToEntityMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<AutorModelCadastro, Autor>();
            Mapper.CreateMap<EditoraModelCadastro, Editora>();
            Mapper.CreateMap<LivroModelCadastro, Livro>();

            Mapper.CreateMap<AutorModelEdicao, Autor>();
            Mapper.CreateMap<EditoraModelEdicao, Editora>();
            Mapper.CreateMap<LivroModelEdicao, Livro>();
        }
    }
}
