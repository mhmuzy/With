using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; /// *** Importando

namespace Projeto.Apresentacao.Models.Request
{
    public class EdicaoFornecimentoRequest
        /// *** Criação da Model de Edição de Fornecimento Request 
    {
        [Required(ErrorMessage = "Por favor, Digita o Código do Fornecimento.")]
        public int CodFornecimento { get; set; }

        [Required(ErrorMessage = "Por favor, informe o fornecedor que fez o fornecimento.")]
        public int Fornecedor { get; set; }

        [Required(ErrorMessage = "Por favor, informe o produto que foi fornecido.")]
        public int Produto { get; set; }
    }
}
