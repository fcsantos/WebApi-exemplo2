using Projeto.Domain.Contracts.Repository;
using Projeto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Infra.Persistence.Repository
{
    public class RepositoryAutor : RepositoryBase<Autor>, IRepositoryAutor
    {
    }
}
