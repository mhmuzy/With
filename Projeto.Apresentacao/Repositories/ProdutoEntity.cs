using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Apresentacao.Repositories
{
    public class ProdutoEntity
    {
        public int CodProduto { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public string Descricao { get; set; }
        public int Fornecedor { get; set; }
        public int Quantidade { get; set; }
    }
}
