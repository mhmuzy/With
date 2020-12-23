using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Infra.Data.Context;
using Projeto.Infra.Data.Contracts;
using Projeto.Infra.Data.Entities;
using System.Linq;

namespace Projeto.Infra.Data.Repositories
{
    public class CompraRepository : BaseRepository<Compra>, ICompraRepository
    {
        private readonly SqlServerContext context;
        public CompraRepository(SqlServerContext context) 
            : base(context)
        {
            this.context = context;
        }
    }
}
