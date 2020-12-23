using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Entidades;

namespace Projeto.Infra.Data.Entities
{
    public class Fornecimento
    {
        public int CodFornecimento { get; set; }
        public Fornecedores Fornecedor { get; set; }
        public Produtos Produto { get; set; }
        public DateTime DataFornecimento { get; set; }
    }
}
