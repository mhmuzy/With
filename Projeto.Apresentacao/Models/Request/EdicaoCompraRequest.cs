using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; /// *** Importando

namespace Projeto.Apresentacao.Models.Request
{
    public class EdicaoCompraRequest
        /// *** Criação da Model de Edição de Compra Request
    {
        [Required(ErrorMessage = "Por favor, Digite o Código da Compra.")]
        /// *** Validação de Campo Obrigatório
        /// *** Atributo Código da Compra
        public int CodCompra { get; set; }

        [Required(ErrorMessage = "Por favor, informe o cliente que fez a compra.")]
        public int Cliente { get; set; }

        [Required(ErrorMessage = "Por favor, informe o produto que foi comprado.")]
        public int Produto { get; set; }

    }
}
