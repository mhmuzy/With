using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Apresentacao.Repositories
{
    public class FornecedorEntity
    {
        public int CodFornecedor { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
    }
}
