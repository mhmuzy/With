using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Entidades
{
    public class Clientes
        /// *** Criação da Entidade Clientes
    {
        /// <summary>
        /// Atributo Código do Cliente
        /// </summary>
        public int CodCliente { get; set; }
        /// <summary>
        /// Atributo Nome do Cliente
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Atributo Produto Revendido do Cliente é a Relação
        /// Da Entidade Produto com a Cliente
        /// </summary>
        public Produtos Produto { get; set; }
        /// <summary>
        /// Atributo Cpf do Cliente
        /// </summary>
        public string Cpf { get; set; }
        /// <summary>
        /// Atributo Telefone do Cliente
        /// </summary>
        public string Telefone { get; set; }
        /// <summary>
        /// Atributo Celular do Cliente
        /// </summary>
        public string Celular { get; set; }
        /// <summary>
        /// Atributo E - mail do Cliente
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Atributo Endereço do Cliente
        /// </summary>
        public string Endereco { get; set; }
    }
}
