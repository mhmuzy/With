using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Entidades;
using Projeto.Entidades.Enums;

namespace Projeto.Infra.Data.Entities
{
    public class Cliente
    {
        public int CodCliente { get; set; }
        public string Nome { get; set; }
        public Produtos Produto { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
    }
}
