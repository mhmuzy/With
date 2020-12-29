using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Infra.Data.Context;
using Projeto.Infra.Data.Contracts;
using Projeto.Infra.Data.Entities;
using System.Linq;

namespace Projeto.Infra.Data.Repositories
{
    public class FornecedorRepository : BaseRepository<Fornecedor>, IFornecedorRepository
    {
        private readonly SqlServerContext context;
        public FornecedorRepository(SqlServerContext context) 
            : base(context)
        {
            this.context = context;
        }

        public Fornecedor GetByCpf(string cpf)
        {
            return context.Set<Fornecedor>().Find(cpf);
        }

        public Fornecedor GetByCnpj(string cnpj)
        {
            return context.Set<Fornecedor>().Find(cnpj);
        }
    }
}
