using Projeto.Application.Contracts;
using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Domain.Contracts.Services;

namespace Projeto.Application.Services
{
    public class ApplicationServiceAutor : ApplicationServiceBase<Autor>, IApplicationServiceAutor
    {
        private readonly IDomainServiceAutor dominio;

        public ApplicationServiceAutor(IDomainServiceAutor dominio) : base(dominio)
        {
            this.dominio = dominio;
        }
    }
}
