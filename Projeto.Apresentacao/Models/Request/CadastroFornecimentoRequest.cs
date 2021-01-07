using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; /// *** Importando

namespace Projeto.Apresentacao.Models.Request
{
    public class CadastroFornecimentoRequest
        /// *** Criação da Model Cadastro de Fornecedor Request
    {
        [Required(ErrorMessage = "Por favor, informe o fornecedor que fez o fornecimento.")]
        public int Fornecedor { get; set; }

        [Required(ErrorMessage = "Por favor, informe o produto a ser fornecido.")]
        public int Produto { get; set; }
    }
}
