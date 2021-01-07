using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Apresentacao.Repositories
{
    public class ProdutoRepository
    {
        private readonly List<ProdutoEntity> produtos;

        public ProdutoRepository()
        {
            produtos = new List<ProdutoEntity>();
        }

        public void Add(ProdutoEntity entity)
        {
            produtos.Add(entity);
        }

        public void Remove(ProdutoEntity entity)
        {
            produtos.Remove(entity);
        }

        public List<ProdutoEntity> GetAll()
        {
            return produtos.OrderBy(p => p.Nome).ToList();
        }

        public ProdutoEntity GetById(int id)
        {
            return produtos.FirstOrDefault(f => f.CodProduto == id);
        }
    }
}
