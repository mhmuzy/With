using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; /// *** Importando

namespace Projeto.Apresentacao.Models.Request
{
    public class CadastroProdutoRequest
        /// *** Criação da Model de Cadastro de Produto de Request
    {
        [MinLength(3, ErrorMessage = "A quantidade mínima de caracter não pode ser inferior a {1} caracteres.")]
        /// *** Validação da Quantidade Mínima de Caracter Permitido
        [MaxLength(200, ErrorMessage = "A Quantidade máxima de caracter não pode ser superior a {1} caracteres.")]
        /// *** Validação da Quantidade Máxima de Caracter Permitido
        [Required(ErrorMessage = "Por favor, Digite o Nome do Produto")]
        /// *** Validação Informando que é Campo Obrigatório
        /// *** Atributo Nome do Produto
        public string Nome { get; set; }


        [Required(ErrorMessage = "Por favor, Digite o Preço do Produto")]
        /// *** Validação Informando que é Campo Obrigatório
        /// *** Atributo Preço do Produto
        public double Preco { get; set; }

        [MinLength(15, ErrorMessage = "A quantidade mínima de caracter não pode ser inferior a {1} caracteres.")]
        /// *** Validação Informando que a Qunatidade de Caracter Mínima não pode ser Inefrior a 15
        [MaxLength(5000, ErrorMessage = "A quantidade máxima de caracter não pode ser superior a {1} caracteres.")]
        /// *** Validação Informando que a Quantidae de Caracter Máxima não pode ser Superior a 5000
        [Required(ErrorMessage = "Por favor, Digite a Descrição do Produto")]
        /// *** Validação Informando que é Campo Obrigatório
        /// *** Atributo Descrição do Produto
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Por favor, informe o fornecedor que forneceu o produto")]
        public int Fornecedor { get; set; }
    }
}
