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
    public class EdicaoProdutoRequest
        /// *** Criação da Model de Edição de Produto Request
    {
        [Required(ErrorMessage = "Por favor, Digite o Código do Produto.")]
        /// *** Validação de Campo Obrigatório
        /// *** Atributo Código do Produto
        public int CodProduto { get; set; }

        [MinLength(15, ErrorMessage = "A quantidade mínima de caracter não pode ser inferior a {1} caracteres.")]
        /// *** Validação de Quantidade Mínima de Caracteres Permitido.
        [MaxLength(200, ErrorMessage = "A quantidade máxima de caracter não pode ser superioir a {1} caracteres.")]
        /// *** Validação de Quantidade Máxima de Caracteres Permitido.
        [Required(ErrorMessage = "Por favor, Digite o Nome do Produto.")]
        /// *** Validação de Campo Obrigatório
        /// *** Atributo Nome do Produto
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, Digite o Fornecedor do Produto.")]
        /// *** Validação de Campo Obrigatório
        /// *** Atributo Fornecedor que Forneceu o Produto, A Entidade Fornecedor se Relaciona com a Entidade Produto
        public Fornecedores Fornecedor { get; set; }

        [Required(ErrorMessage = "Por favor, Digite o Preço do Produto.")]
        /// *** Validação de Campo Obrigatório
        /// *** Atributo Preço do Produto
        public double Preco { get; set; }

        [MinLength(15, ErrorMessage = "A quantidade mínima de caracter não pode ser inferior a {1} caracteres.")]
        /// *** Validação da Quantidade Mínima de Caracteres Permitida.
        [MaxLength(5000, ErrorMessage = "A quantidade máxima de caracter não pode ser superior a {1} caracteres.")]
        /// *** Validação da Quantidade Máxima de Caracteres Permitida
        [Required(ErrorMessage = "Por favor, Digite a Descrição do Produto.")]
        /// *** Validação de Campo Obrigatório
        /// *** Atributo Descrição do Produto
        public string Descricao { get; set; }
    }
}
