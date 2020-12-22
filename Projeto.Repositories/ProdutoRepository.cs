using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Entidades;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Repositories
{
    public class ProdutoRepository
    {
        private readonly List<Produtos> produtos;

        public ProdutoRepository()
        {
            produtos = new List<Produtos>();
        }

        public void Add(Produtos entity)
        {
            produtos.Add(entity);
        }

        public void Remove(Produtos entity)
        {
            produtos.Remove(entity);
        }

        public List<Produtos> GetAll()
        {
            return produtos.OrderBy(p => p.Nome).ToList();
        }

        public Produtos GetById(int id)
        {
            return produtos.FirstOrDefault(p => p.CodProduto == id);
        }
    }
}
