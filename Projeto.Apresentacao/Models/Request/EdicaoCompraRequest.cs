using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; /// *** Importando
using Projeto.Entidades; /// <summary>
///  Importando
/// </summary>

namespace Projeto.Apresentacao.Models.Request
{
    public class EdicaoCompraRequest
        /// *** Criação da Model de Edição de Compra Request
    {
        [Required(ErrorMessage = "Por favor, Digite o Código da Compra.")]
        /// *** Validação de Campo Obrigatório
        /// *** Atributo Código da Compra
        public int CodCompra { get; set; }

        [Required(ErrorMessage = "Por favor, Digite o Cliente que fez a Compra.")]
        /// *** Validação de Campo Obrigatório
        /// *** Atributo Cliente que vai Fazer a Compra, A Relação da Entidade Cliente com a Entidade Compra
        public Clientes Cliente { get; set; }

        [Required(ErrorMessage = "Por favor, Digite o Produto da Compra.")]
        /// *** Validação de Campo Obrigatório
        /// *** Atributo Produto que foi Comprado, A Relação da Entidade Produto Com a Compra
        public Produtos Produto { get; set; }
    }
}
