using System;
using System.Collections.Generic;
using Projeto.Entidades;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Repositories
{
    public class ClienteRepository
    {
        private readonly List<Clientes> clientes;

        public ClienteRepository()
        {
            clientes = new List<Clientes>();
        }

        public void Add(Clientes entity)
        {
            clientes.Add(entity);
        }

        public void Remove(Clientes entity)
        {
            clientes.Remove(entity);
        }

        public List<Clientes> GetAll()
        {
            return clientes.OrderBy(c => c.Nome).ToList();
        }

        public Clientes GetById(int id)
        {
            return clientes.FirstOrDefault(c => c.CodCliente == id);
        }
    }
}
