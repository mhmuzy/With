using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Apresentacao.Repositories
{
    public class FornecimentoEntity
    {
        public int CodFornecimento { get; set; }
        public DateTime DataFornecimento { get; set; }
        public int Fornecedor { get; set; }
        public int Produto { get; set; }
    }
}
