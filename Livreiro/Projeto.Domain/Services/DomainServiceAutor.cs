using Projeto.Domain.Contracts.Repository;
using Projeto.Domain.Contracts.Services;
using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Domain.Services
{
    public class DomainServiceAutor : DomainServiceBase<Autor>, IDomainServiceAutor
    {
        private readonly IRepositoryAutor repositorio;

        public DomainServiceAutor(IRepositoryAutor repositorio) : base(repositorio)
        {
            this.repositorio = repositorio;
        }
    }
}
