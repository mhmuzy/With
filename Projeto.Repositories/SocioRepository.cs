using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Entidades;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Repositories
{
    public class SocioRepository
    {
        private readonly List<Socios> socios;

        public SocioRepository()
        {
            socios = new List<Socios>();
        }

        public void Add(Socios entity)
        {
            socios.Add(entity);
        }

        public void Remove(Socios entity)
        {
            socios.Remove(entity);
        }

        public List<Socios> GetAll()
        {
            return socios.OrderBy(s => s.Nome).ToList();
        }

        public Socios GetById(int id)
        {
            return socios.FirstOrDefault(s => s.Matricula == id);
        }
    }
}
