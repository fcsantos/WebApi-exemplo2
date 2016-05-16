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
    [RoutePrefix("api/autor")]
    public class AutorController : ApiController
    {
        private readonly IApplicationServiceAutor appAutor;

        public AutorController(IApplicationServiceAutor appAutor)
        {
            this.appAutor = appAutor;
        }

        [HttpPost]
        [Route("cadastro")] //api/autor/cadastro
        public HttpResponseMessage Post([FromBody]AutorModelCadastro model)
        {
            try
            {
                //convertendo
                var a = Mapper.Map<AutorModelCadastro, Autor>(model);
                appAutor.Cadastrar(a);

                return Request.CreateResponse(HttpStatusCode.OK, "Dados gravados.");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);                
            }
        }

        [HttpPut]
        [Route("atualizar")] //api/autor/atualizar
        public HttpResponseMessage Put(AutorModelEdicao model)
        {
            try
            {
                //convertendo
                var a = Mapper.Map<AutorModelEdicao, Autor>(model);
                appAutor.Atualizar(a);

                return Request.CreateResponse(HttpStatusCode.OK, "Dados atualizados.");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }


        [HttpDelete]
        [Route("excluir")] //api/autor/excluir
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var a = appAutor.ObterPorId(id);
                if (a != null)
                {
                    appAutor.Remover(a);
                    return Request.CreateResponse(HttpStatusCode.OK, "Dados excluídos.");
                }else
                {
                    return Request.CreateResponse(HttpStatusCode.Forbidden, "Autor não encontrado.");
                }
                                                
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [HttpGet]
        [Route("listar")] //api/autor/listar
        public HttpResponseMessage GetValues()
        {
            try
            {
                var model = new List<AutorModelConsulta>();
                foreach (var a in appAutor.ObterTodos())
                {
                    var item = Mapper.Map<Autor, AutorModelConsulta>(a);
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
        [Route("obter")] //api/autor/obter
        public HttpResponseMessage GetValue(int id)
        {
            try
            {
                var a = appAutor.ObterPorId(id);
                if (a != null)
                {
                    var model = Mapper.Map<Autor, AutorModelConsulta>(a);
                    return Request.CreateResponse(HttpStatusCode.OK, model);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Forbidden, "Autor não encontrado.");
                }                
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }
    }
}
