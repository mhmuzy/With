using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Entidades;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Repositories
{
    public class CompraRepository
    {
        private readonly List<Compra> compras;

        public CompraRepository()
        {
            compras = new List<Compra>();
        }

        public void Add(Compra entity)
        {
            compras.Add(entity);
        }

        public void Remove(Compra entity)
        {
            compras.Remove(entity);
        }

        public List<Compra> GetAll()
        {
            return compras.OrderBy(c => c.Produto.Nome).ToList();
        }

        public Compra GetById(int id)
        {
            return compras.FirstOrDefault(c => c.CodCompra == id);
        }
    }
}
