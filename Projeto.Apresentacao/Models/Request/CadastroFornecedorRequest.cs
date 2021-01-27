using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; /// <summary>
/// Importando
/// </summary>

namespace Projeto.Apresentacao.Models.Request
{
    public class CadastroFornecedorRequest
        /// *** Criação da Model de Cadastro de Fornecedor Request
    {
        [MinLength(15, ErrorMessage = "A quantidade mínima de caracteres não pode ser inferior a {1} caracteres.")]
        /// *** Validação da Quantidade Mínima de caracteres Permitida
        [MaxLength(200, ErrorMessage = "A quantidade máxima de caracteres não pode ser superior a {1} caracteres.")]
        /// *** Validação da Quantidade Máxima de caracteres Permitida
        [Required(ErrorMessage = "Por favor, digite o nome do Fornecedor.")]
        /// *** Validação de Campo Obrigatório
        /// *** Atributo Nome do Fornecedor
        public string Nome { get; set; }

        [MinLength(14, ErrorMessage = "Formato de Cpf Inválido.")]
        /// *** Validação de Formato do Cpf do Fornecedor
        [MaxLength(14, ErrorMessage = "Formato de Cpf Inválido.")]
        /// *** Validação do Formato do Cpf do Fornecedor
        /// *** Atributo Cpf do Fornecedor
        public string Cpf { get; set; }

        [MinLength(16, ErrorMessage = "Formato de Cnpj Inválido.")]
        /// *** Validação do Formato do Cnpj do Fornecedor
        [MaxLength(18, ErrorMessage = "Formato de Cnpj Inválido.")]
        /// *** Validação do Formato do Cnpj do Fornecedor
        /// *** Atributo Cnpj do Fornecedor
        public string Cnpj { get; set; }

        [MinLength(12, ErrorMessage = "Formato de Telefone Inválido.")]
        /// *** Validação do Formato de Telefone
        [MaxLength(14, ErrorMessage = "Formato de Telefone Inválido.")]
        /// *** Validação do Formato do Telefone do Fornecedor
        /// *** Atributo Telefone do Fornecedor
        public string Telefone { get; set; }

        [MinLength(13, ErrorMessage = "Formato de Celular Inválido.")]
        /// *** Validação do Formato de Celular
        [MaxLength(15, ErrorMessage = "Formato de Celular Inválido.")]
        /// *** Validação do Formato do Celular
        /// *** Atributo Celular do Fornecedor
        public string Celular { get; set; }

        [EmailAddress(ErrorMessage = "E - mail Inválido.")]
        /// *** Validação do E - mail do Fornecedor
        [Required(ErrorMessage = "Por favor, Digita o E - mail do Fornecedor.")]
        /// *** Validação Informando que é Campo Obrigatório
        /// *** Atributo E - mail do Fornecedor
        public string Email { get; set; }

        [MinLength(10, ErrorMessage = "A quantidade mínima de caracter não pode ser inferior de {1} caracteres.")]
        /// *** Validação Informando a Quantidade Mínima Permitida
        [MaxLength(200, ErrorMessage = "A quantidade máxima de caracter não pode ser superior de {1} caracteres.")]
        /// *** Validação Informando a Quantidade Máxima Permitida
        [Required(ErrorMessage = "Por favor, Digita o Endereço do Fornecedor")]
        /// *** Validação Informando Campo Obrigatório
        /// *** Atributo Endereço do Fornecedor
        public string Endereco { get; set; }
    }
}
