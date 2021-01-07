using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Apresentacao.Repositories
{
    public class ClienteRepository
    {
        private readonly List<ClienteEntity> clientes;

        public ClienteRepository()
        {
            clientes = new List<ClienteEntity>();
        }

        public void Add(ClienteEntity entity)
        {
            clientes.Add(entity);
        }

        public void Remove(ClienteEntity entity)
        {
            clientes.Remove(entity);
        }

        public List<ClienteEntity> GetAll()
        {
            return clientes.OrderBy(c => c.Nome).ToList();
        }

        public ClienteEntity GetById(int id)
        {
            return clientes.FirstOrDefault(c => c.CodCliente == id);
        }
    }
}
