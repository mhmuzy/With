using System;
using System.Collections.Generic;
using System.Text;


namespace Projeto.Infra.Data.Entities
{
    public class Cliente
    {
        public int CodCliente { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public int FormaPagamento { get; set; }
    }
}
