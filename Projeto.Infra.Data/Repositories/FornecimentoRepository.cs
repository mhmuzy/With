﻿using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Infra.Data.Context;
using Projeto.Infra.Data.Contracts;
using Projeto.Infra.Data.Entities;
using System.Linq;

namespace Projeto.Infra.Data.Repositories
{
    public class FornecimentoRepository : BaseRepository<Fornecimento>, IFornecimentoRepository
    {
        private readonly SqlServerContext context;
        public FornecimentoRepository(SqlServerContext context) : base(context)
        {
            this.context = context;
        }
    }
}
