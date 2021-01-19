using System;
using System.Collections.Generic;
using System.Text;
//using Projeto.Entidades;

namespace Projeto.Infra.Data.Entities
{
    public class Produto
    {
        public int CodProduto { get; set; }
        public string Nome { get; set; }
        public int Fornecedor { get; set; }
        public double Preco { get; set; }
        public string Descricao { get; set; }
    }
}
