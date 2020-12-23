using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Entidades;

namespace Projeto.Infra.Data.Entities
{
    public class Compra
    {
        public int CodCompra { get; set; }
        public Clientes Cliente { get; set; }
        public Produtos Produto { get; set; }
        public DateTime DataCompra { get; set; }
    }
}
