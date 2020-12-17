using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Entidades
{
    public class Compra
        /// *** Criação da Entidade Compra
    {
        /// <summary>
        ///  Atributo Código da Compra
        /// </summary>
        public int CodCompra { get; set; }
        /// <summary>
        /// Atributo Cliente que Fez a Compra
        /// </summary>
        public Clientes Cliente { get; set; }
        /// <summary>
        /// Atributo Produto que Foi feito na Compra
        /// </summary>
        public Produtos Produto { get; set; }
        /// <summary>
        /// Atributo Data da Compra
        /// </summary>
        public DateTime DataCompra { get; set; }
    }
}
