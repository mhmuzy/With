using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Entidades;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Repositories
{
    public class FornecedorRepository
    {
        private readonly List<Fornecedores> fornecedores;

        public FornecedorRepository()
        {
            fornecedores = new List<Fornecedores>();
        }

        public void Add(Fornecedores entity)
        {
            fornecedores.Add(entity);
        }

        public void Remove(Fornecedores entity)
        {
            fornecedores.Remove(entity);
        }

        public List<Fornecedores> GetAll()
        {
            return fornecedores.OrderBy(f => f.Nome).ToList();
        }

        public Fornecedores GetById(int id)
        {
            return fornecedores.FirstOrDefault(f => f.CodFornecedor == id);
        }
    }
}
