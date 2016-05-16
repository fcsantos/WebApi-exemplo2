using Projeto.Domain.Contracts.Services;
using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Domain.Contracts.Repository;

namespace Projeto.Domain.Services
{
    public class DomainServiceEditora : DomainServiceBase<Editora>, IDomainServiceEditora
    {
        private readonly IRepositoryEditora repositorio;

        public DomainServiceEditora(IRepositoryEditora repositorio) : base(repositorio)
        {
            this.repositorio = repositorio;
        }
    }
}
