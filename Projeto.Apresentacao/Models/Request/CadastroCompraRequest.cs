using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; 

namespace Projeto.Apresentacao.Models.Request
{
    public class CadastroCompraRequest
        /// *** Criação da Model Cadastro de Compra Request
    {
        [Required(ErrorMessage = "Por favor, informe o cliente que vai fazer a compra.")]
        public int Cliente { get; set; }
        
        [Required(ErrorMessage = "Por favor, informe o produto a ser comprado.")]
        public int Produto { get; set; }
    }
}
