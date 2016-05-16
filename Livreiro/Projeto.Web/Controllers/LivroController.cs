using AutoMapper;
using Projeto.Application.Contracts;
using Projeto.Entities;
using Projeto.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Projeto.Web.Controllers
{
    [AllowAnonymous] //não exige autorização
    [RoutePrefix("api/livro")]
    public class LivroController : ApiController
    {
        private readonly IApplicationServiceLivro appLivro;

        public LivroController(IApplicationServiceLivro appLivro)
        {
            this.appLivro = appLivro;
        }

        [HttpPost]
        [Route("cadastrar")] //api/livro/cadastrar
        public HttpResponseMessage Post(LivroModelCadastro model)
        {
            try
            {
                var l = Mapper.Map<LivroModelCadastro, Livro>(model);
                appLivro.Cadastrar(l, model.AutorId, model.EditoraId);

                return Request.CreateResponse(HttpStatusCode.OK, "Dados gravados.");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);                                
            }                
        }
        
        [HttpPut]
        [Route("atualizar")] //api/livro/atualizar
        public HttpResponseMessage Put(LivroModelEdicao model)
        {
            try
            {
                var l = Mapper.Map<LivroModelEdicao, Livro>(model);
                appLivro.Atualizar(l);

                return Request.CreateResponse(HttpStatusCode.OK, "Dados atualizados.");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [HttpDelete]
        [Route("excluir")] //api/livro/excluir
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var l = appLivro.ObterPorId(id);
                if (l != null)
                {
                    appLivro.Remover(l);
                    return Request.CreateResponse(HttpStatusCode.OK, "Dados excluídos.");
                }else
                {
                    return Request.CreateResponse(HttpStatusCode.Forbidden, "Livro não encontrado.");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [HttpGet]
        [Route("listar")] //api/livro/listar
        public HttpResponseMessage GetValues()
        {
            try
            {
                var model = new List<LivroModelConsulta>();
                foreach (var l in appLivro.ObterTodos())
                {
                    var item = Mapper.Map<Livro, LivroModelConsulta>(l);
                    model.Add(item);
                }

                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);                
            }
        }

        [HttpGet]
        [Route("filtrarporautor")] //api/livro/filtrarporautor
        public HttpResponseMessage GetValues(LivroModelFiltroPorAutor model)
        {
            try
            {
                var lista = new List<LivroModelConsulta>();
                foreach (var l in appLivro.ObterPorAutor(model.AutorId))
                {
                    var item = Mapper.Map<Livro, LivroModelConsulta>(l);
                    lista.Add(item);
                }

                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);                
            }
        }

        [HttpGet]
        [Route("filtrarporeditora")] //api/livro/filtrarporeditora
        public HttpResponseMessage GetValues(LivroModelFiltroPorEditora model)
        {
            try
            {
                var lista = new List<LivroModelConsulta>();
                foreach (var l in appLivro.ObterPorEditora(model.EditoraId))
                {
                    var item = Mapper.Map<Livro, LivroModelConsulta>(l);
                    lista.Add(item);
                }

                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [HttpGet]
        [Route("obter")] //api/livro/obter
        public HttpResponseMessage GetValue(int id)
        {
            try
            {
                var l = appLivro.ObterPorId(id);
                if (l != null)
                {
                    var model = Mapper.Map<Livro, LivroModelConsulta>(l);
                    return Request.CreateResponse(HttpStatusCode.OK, model);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Forbidden, "Livro não encontrado.");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);                
            }
        }
    }
}
