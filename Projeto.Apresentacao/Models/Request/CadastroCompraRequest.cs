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
    public class CadastroCompraRequest
        /// *** Criação da Model Cadastro de Compra Request
    {
        [Required(ErrorMessage = "Por favor, Digita o Cliente que fez a Compra.")]
        /// *** Validação de campo Obrigatório
        /// *** Atributo Cliente que fez a Compra, a Entidade Cliente é Relacionada a Entidade Compra
        public Clientes Cliente { get; set; }

        [Required(ErrorMessage = "Por favor, Digita o Produto que foi Comprado.")]
        /// *** Validação de campo Obrigatório
        /// *** Atributo Produto que foi comprado, a Entidade Produto é Relacionado a Entidade Compra
        public Produtos Produto { get; set; }
    }
}
