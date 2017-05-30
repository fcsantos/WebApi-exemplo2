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
    [RoutePrefix("api/editora")]
    public class EditoraController : ApiController
    {
        private readonly IApplicationServiceEditora appEditora;

        public EditoraController(IApplicationServiceEditora appEditora)
        {
            this.appEditora = appEditora;
        }

        [HttpPost]
        [Route("cadastrar")] //api/editora/cadastrar
        public HttpResponseMessage Post(EditoraModelCadastro model)
        {
            try
            {
                var e = Mapper.Map<EditoraModelCadastro, Editora>(model);
                appEditora.Cadastrar(e);

                return Request.CreateResponse(HttpStatusCode.OK, "Dados cadastrados.");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);                
            }
        }

        [HttpPut]
        [Route("atualizar")] //api/editora/atualizar
        public HttpResponseMessage Put(EditoraModelEdicao model)
        {
            try
            {
                var e = Mapper.Map<EditoraModelEdicao, Editora>(model);
                appEditora.Atualizar(e);

                return Request.CreateResponse(HttpStatusCode.OK, "Dados atualizados.");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);                
            }
        }

        [HttpDelete]
        [Route("excluir")] //api/editora/excluir
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var e = appEditora.ObterPorId(id);
                if (e != null)
                {
                    appEditora.Remover(e);
                    return Request.CreateResponse(HttpStatusCode.OK, "Dados excluídos.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Forbidden, "Editora não encontrada.");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);                
            }
        }

        [HttpGet]
        [Route("listar")] //api/editora/listar
        public HttpResponseMessage GetValues()
        {
            try
            {
                var model = new List<EditoraModelConsulta>();
                foreach (var e in appEditora.ObterTodos())
                {
                    var item = Mapper.Map<Editora, EditoraModelConsulta>(e);
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
        [Route("obter")] //api/editora/obter
        public HttpResponseMessage GetValue(int id)
        {
            try
            {
                var e = appEditora.ObterPorId(id);
                if (e != null)
                {
                    var model = Mapper.Map<Editora, EditoraModelConsulta>(e);
                    return Request.CreateResponse(HttpStatusCode.OK, model);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Forbidden, "Editora não encontrada");
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }
    }
}
