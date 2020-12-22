using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Entidades;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Repositories
{
    public class FornecimentoRepository
    {
        private readonly List<Fornecimento> fornecimentos;

        public FornecimentoRepository()
        {
            fornecimentos = new List<Fornecimento>();
        }

        public void Add(Fornecimento entity)
        {
            fornecimentos.Add(entity);
        }

        public void Remove(Fornecimento entity)
        {
            fornecimentos.Remove(entity);
        }

        public List<Fornecimento> GetAll()
        {
            return fornecimentos.OrderBy(f => f.Fornecedor.Nome).ToList();
        }

        public Fornecimento GetById(int id)
        {
            return fornecimentos.FirstOrDefault(f => f.CodFornecimento == id);
        }
    }
}
