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
    public class EdicaoFornecimentoRequest
        /// *** Criação da Model de Edição de Fornecimento Request 
    {
        [Required(ErrorMessage = "Por favor, Digita o Código do Fornecimento.")]
        public int CodFornecimento { get; set; }
        
        [Required(ErrorMessage = "Por favor, Digita o Fornecedor.")]
        public Fornecedores Fornecedor { get; set; }

        [Required(ErrorMessage = "Por favor, Digita o Produto.")]
        public Produtos Produto { get; set; }
    }
}
