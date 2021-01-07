using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Apresentacao.Repositories
{
    public class CompraEntity
    {
        public int CodCompra { get; set; }
        public DateTime DataCompra { get; set; }
        public int Cliente { get; set; }
        public int Produto { get; set; }
    }
}
