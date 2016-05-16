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
    public class ApplicationServiceEditora : ApplicationServiceBase<Editora>, IApplicationServiceEditora
    {
        private readonly IDomainServiceEditora dominio;

        public ApplicationServiceEditora(IDomainServiceEditora dominio) : base(dominio)
        {
            this.dominio = dominio;
        }
    }
}
