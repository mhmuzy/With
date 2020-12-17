using System;

namespace Projeto.Entidades
{
    public class Produtos
        /// *** Criação da Entidade Produtos
    {
        /// <summary>
        /// Atributo Código do Produto
        /// </summary>
        public int CodProduto { get; set; }
        /// <summary>
        /// Atributo Nome do Produto
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Atributo Preço do Produto
        /// </summary>
        /// *** Associação da Entidade Produto e Fornecedor
        public Fornecedores Fornecedor { get; set; }
        /// <summary>
        /// Atributo Preço do Produto
        /// </summary>
        public double Preco { get; set; }
        /// <summary>
        /// Atributo Descrição do Produto
        /// </summary>
        public string Descricao { get; set; }
    }
}
