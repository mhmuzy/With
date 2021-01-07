using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Apresentacao.Repositories
{
    public class CompraRepository
    {
        private readonly List<CompraEntity> compras;

        public CompraRepository()
        {
            compras = new List<CompraEntity>();
        }

        public void Add(CompraEntity entity)
        {
            compras.Add(entity);
        }

        public void Remove(CompraEntity entity)
        {
            compras.Remove(entity);
        }

        public List<CompraEntity> GetAll()
        {
            return compras.OrderBy(c => c.DataCompra).ToList();
        }

        public CompraEntity GetById(int id)
        {
            return compras.FirstOrDefault(c => c.CodCompra == id);
        }
    }
}
