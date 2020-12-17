using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Entidades
{
    public class Fornecimento
        /// *** Criação da Entidade de Fornecimento
    {
        /// <summary>
        ///  Atributo Código do Fornecimento
        /// </summary>
        public int CodFornecimento { get; set; }
        /// <summary>
        /// Atributo Fornecedor que vai fazer o Fornecimento
        /// </summary>
        public Fornecedores Fornecedor { get; set; }
        /// <summary>
        /// Atributo Produto que o Fornecedor vai Fornecer
        /// </summary>
        public Produtos Produto { get; set; }
        /// <summary>
        /// Atributo Data do Fornecimento
        /// </summary>
        public DateTime DataFornecimento { get; set; }
    }
}
