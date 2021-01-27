using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; /// *** Importando

namespace Projeto.Apresentacao.Models.Request
{
    public class EdicaoFornecedorRequest
        /// *** Criação da Model de Edição do Fornecedor Request
    {
        [Required(ErrorMessage = "Por favor, Digite o Código do Fornecedor.")]
        /// *** Validação de Campo Obrigatório
        /// *** Atributo Código do Fornecedor
        public int CodFornecedor { get; set; }

        [MinLength(15, ErrorMessage = "A quantidade mínima de caracter não pode ser inferior a {1} caracteres.")]
        /// *** Validação Quantidade Mínima de Caracter Permitida
        [MaxLength(200, ErrorMessage = "A quantidade máxima de caracter não pode ser superior a {1} caracteres.")]
        /// *** Validação Quantidade Máxima de Caracter Permitida
        [Required(ErrorMessage = "Por favor, Digite o Nome do Fornecedor.")]
        /// *** Validação de Campo Obrigatório
        /// *** Atributo Nome do Fornecedor
        public string Nome { get; set; }

        [MinLength(14, ErrorMessage = "Formato de Cpf Inválido.")]
        /// *** Validação de Formato de Cpf
        [MaxLength(14, ErrorMessage = "Formato de Cpf Inválido.")]
        /// *** Validação de Formato de Cpf
        /// *** Atributo Cpf do Fornecedor
        public string Cpf { get; set; }

        [MinLength(16, ErrorMessage = "Formato de Cnpj Inválido.")]
        /// *** Validação Formato de Cnpj
        [MaxLength(18, ErrorMessage = "Formato de Cnpj Inválido.")]
        /// *** Validação Formato de Cnpj
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
        /// *** Validação E - mail Válido
        [Required(ErrorMessage = "Por favor, digita o E - mail do Fornecedor.")]
        /// *** Validação de Campo Obrigatório
        /// *** Atributo E - mail do Fornecedor
        public string Email { get; set; }

        [MinLength(15, ErrorMessage = "A quantidade mínima de caracter não pode ser inferior a {1} caracteres.")]
        /// *** Validação Quantidade Mínima de Caracter Permitida
        [MaxLength(200, ErrorMessage = "A quantidade máxima de caracter não pode ser superior a {1} caracteres.")]
        /// *** Validação Quantidade Máxima de Caracter Permitida
        [Required(ErrorMessage = "Por favor, Digita o Endereço do Cliente.")]
        /// *** Validação de Campo Obrigatório
        /// *** Atributo Endereço do Fornecedor
        public string Endereco { get; set; }
    }
}
