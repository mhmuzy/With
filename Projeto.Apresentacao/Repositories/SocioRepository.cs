using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Apresentacao.Repositories
{
    public class SocioRepository
    {
        private readonly List<SocioEntity> socios;

        public SocioRepository()
        {
            socios = new List<SocioEntity>();
        }

        public void Add(SocioEntity entity)
        {
            socios.Add(entity);
        }

        public void Remove(SocioEntity entity)
        {
            socios.Remove(entity);
        }

        public List<SocioEntity> GetAll()
        {
            return socios.OrderBy(s => s.Nome).ToList();
        }

        public SocioEntity GetById(int id)
        {
            return socios.FirstOrDefault(s => s.Matricula == id);
        }
    }
}
