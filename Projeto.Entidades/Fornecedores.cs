using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Entidades
{
    public class Fornecedores
        /// *** Declaração da Entidade Fornecedores
    {
        /// <summary>
        /// Atributo Código do Fornecedor
        /// </summary>
        public int CodFornecedor { get; set; }
        /// <summary>
        /// Atributo Nome do Fornecedor
        /// </summary>
        public string Nome { get; set; }
        /// *** Atributo Cpf do Fornecedor
        public string Cpf { get; set; }
        /// <summary>
        /// Atributo Cnpj do Fornecedor 
        /// </summary>
        public string Cnpj { get; set; }
        /// <summary>
        /// Atributo Telefone do Fornecedor
        /// </summary>
        public string Telefone { get; set; }
        /// <summary>
        /// Atributo Celular do Fornecedor
        /// </summary>
        public string Celular { get; set; }
        /// <summary>
        /// Atributo E - mail do Fornecedor
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Atributo Endereço do Fornecedor
        /// </summary>
        public string Endereco { get; set; }
    }
}
