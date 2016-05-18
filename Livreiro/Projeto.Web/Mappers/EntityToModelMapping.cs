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
    public class EntityToModelMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Livro, LivroModelConsulta>()
                .ForMember(dest => dest.AutorId, m => m.MapFrom(p => p.Autor.IdAutor))
                .ForMember(dest => dest.NomeAutor, m => m.MapFrom(p => p.Autor.Nome))
                .ForMember(dest => dest.EditoraId, m => m.MapFrom(p => p.Editora.IdEditora))
                .ForMember(dest => dest.NomeEditora, m => m.MapFrom(p => p.Editora.Nome));

            Mapper.CreateMap<Autor, AutorModelConsulta>()
                .ForMember(dest => dest.QtdLivros, m => m.MapFrom(e => e.Livros != null ? e.Livros.Count() : 0));

            Mapper.CreateMap<Editora, EditoraModelConsulta>()
                .ForMember(dest => dest.QtdLivrosPublicados, m => m.MapFrom(e => e.Livros != null ? e.Livros.Count() : 0));
        }
    }
}
