using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; /// *** Importando

namespace Projeto.Apresentacao.Models.Request
{
    public class EdicaoClienteRequest
        /// *** Criação da Model de Edição Cliente Request
    {
        [Required(ErrorMessage = "Por favor, digite o Código do Cliente.")]
        /// *** Validação de Campo Obrigatório
        /// *** Atributo Código do Cliente
        public int CodCliente { get; set; }

        [MinLength(15, ErrorMessage = "A quantidade mínima de caracter não pode ser inferior a {1} caracteres.")]
        /// *** Validação da Quantidade Mínima de Caracter
        [MaxLength(200, ErrorMessage = "A quantidade máxima de caracter não pode ser superior a {1} caracteres.")]
        /// *** Validação da Quantidade Máxima de Caracter
        [Required(ErrorMessage = "Por favor, Digite o Nome do Cliente.")]
        /// *** Validação de Campo Obrigatório
        /// *** Atributo Nome do Cliente
        public string Nome { get; set; }

        [MinLength(14, ErrorMessage = "Formato de Cpf Inválido.")]
        /// *** Validação do Formato de Cpf
        [MaxLength(14, ErrorMessage = "Formato de Cpf Inválido.")]
        /// *** Validação do Formato de Cpf
        [Required(ErrorMessage = "Por favor, Digite o Cpf do Cliente.")]
        /// *** Validação de Campo Obrigatório
        /// *** Atributo Cpf do Cliente
        public string Cpf { get; set; }

        [MinLength(12, ErrorMessage = "Formato de Telefone Inválido.")]
        /// *** Validação do Formato de Telefone
        [MaxLength(14, ErrorMessage = "Formato de Telefone Inválido.")]
        /// *** Validação do Formato de Telefone
        /// *** Atributo Telefone do Cliente
        public string Telefone { get; set; }

        [MinLength(13, ErrorMessage = "Formato de Celular Inválido.")]
        /// *** Validação do Formato de Celular
        [MaxLength(15, ErrorMessage = "Formato de Celular Inválido.")]
        /// *** Validação do Formato de Celular
        /// *** Atributo Celular do Cliente
        public string Celular { get; set; }

        [EmailAddress(ErrorMessage = "E - mail Inválido.")]
        /// *** Validação de E - mail Válido
        [Required(ErrorMessage = "Por favor, Digite o E - mail do Cliente.")]
        /// *** Validação de Campo Obrigatório
        public string Email { get; set; }

        [MinLength(15, ErrorMessage = "A quantidade mínima de caracter é de {1} caracteres.")]
        /// *** Validação de Quantidade Mínima de Caracter Permitido.
        [MaxLength(200, ErrorMessage = "A quantidade máxima de caracter é de {1} caracteres.")]
        /// *** Validação de Quantidade Máxima de Caracter Permitido.
        [Required(ErrorMessage = "Por favor, digite o Endereço do Cliente.")]
        /// *** Validação de Campo Obrigatório
        /// *** Atributo Endereço do Cliente
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Por favor, Digite a Forma de Pagamento.")]
        public int FormaPagamento { get; set; }

    }
}
