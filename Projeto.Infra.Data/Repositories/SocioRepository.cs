using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Infra.Data.Context;
using Projeto.Infra.Data.Contracts;
using Projeto.Infra.Data.Entities;
using System.Linq;

namespace Projeto.Infra.Data.Repositories
{
    public class SocioRepository : BaseRepository<Socio>, ISocioRepository
    {
        private readonly SqlServerContext context;
        public SocioRepository(SqlServerContext context) 
            : base(context)
        {
            this.context = context;
        }
    }
}
