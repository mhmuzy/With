using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Apresentacao.Repositories
{
    public class FornecimentoRepository
    {
        private readonly List<FornecimentoEntity> fornecimentos;

        public FornecimentoRepository()
        {
            fornecimentos = new List<FornecimentoEntity>();
        }

        public void Add(FornecimentoEntity entity)
        {
            fornecimentos.Add(entity);
        }

        public void Remove(FornecimentoEntity entity)
        {
            fornecimentos.Remove(entity);
        }

        public List<FornecimentoEntity> GetAll()
        {
            return fornecimentos.OrderBy(f => f.DataFornecimento).ToList();
        }

        public FornecimentoEntity GetById(int id)
        {
            return fornecimentos.FirstOrDefault(f => f.CodFornecimento == id);
        }

    }
}
