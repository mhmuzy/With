using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; /// *** Importando
using Projeto.Entidades; /// <summary>
/// Importando
/// </summary>

namespace Projeto.Apresentacao.Models.Request
{
    public class CadastroFornecimentoRequest
        /// *** Criação da Model Cadastro de Fornecedor Request
    {
        [Required(ErrorMessage = "Por favor, Digita o Fornecedor que Fez o Fornecimento.")]
        /// *** Validação de Campo Obrigatório
        /// *** Atributo Fornecedor, Entidade Fornecedor Se Relaciona com a Entidade Fornecimento
        public Fornecedores Fornecedor { get; set; }

        [Required(ErrorMessage = "Por favor, Digita o Produto que foi Fornecido.")]
        /// *** Validação de campo Obrigatório
        /// *** Atributo Produto, Entidade Produto se relaciona com a Entidade Fornecimento
        public Produtos Produto { get; set; }
    }
}
