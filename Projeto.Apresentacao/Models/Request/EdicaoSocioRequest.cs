using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; /// <summary>
/// Importando
/// </summary>

namespace Projeto.Apresentacao.Models.Request
{
    public class EdicaoSocioRequest
        /// *** Criação da Model de Edição Request
    {
        [Required(ErrorMessage = "Por favor, Digite a Matrícula do Sócio.")]
        /// *** Validação de Campo Obrigatório
        /// *** Atributo Matrícula do Sócio
        public int Matricula { get; set; }

        [MinLength(15, ErrorMessage = "A quantidade mínima de caracter não pode ser inferior a {1} caracteres.")]
        /// *** Validação de Quantidade Mínima de Caracteres
        [MaxLength(200, ErrorMessage = "A quantidade máxima de caracter não pode ser superior a {1} caracteres.")]
        /// *** Validação de Quantidade Máxima de Caracteres
        [Required(ErrorMessage = "Por favor, Digite o Nome do Sócio.")]
        /// *** Validação de Campo Obrigatório
        /// *** Atributo Nome do Sócio
        public string Nome { get; set; }

        [MinLength(12, ErrorMessage = "Formato de Telefone Inválido.")]
        /// *** Formato de Telefone
        [MaxLength(14, ErrorMessage = "Formato de Telefone Inválido.")]
        /// *** Formato de Telefone
        /// *** Atributo Telefone do Sócio
        public string Telefone { get; set; }

        [MinLength(13, ErrorMessage = "Formato de Celular Inválido.")]
        /// *** Formato de Celular
        [MaxLength(15, ErrorMessage = "Formato de Celular Inválido.")]
        /// *** Formato de Celular
        /// *** Atributo Celular do Sócio
        public string Celular { get; set; }

        [MinLength(14, ErrorMessage = "Formato de Cpf Inválido.")]
        /// *** Formato de Cpf
        [MaxLength(14, ErrorMessage = "Formato de Cpf Inválido.")]
        /// *** Formato de Cpf
        /// *** Atributo Cpf do Sócio
        public string Cpf { get; set; }

        [EmailAddress(ErrorMessage = "E - mail Inválido.")]
        /// *** Validação de E - mail
        /// *** Atributo E - mail do Sócio
        public string Email { get; set; }

        [MinLength(15, ErrorMessage = "A quantidade mínima de caracter não pode ser inferior a {1} caracteres.")]
        /// *** Validação de Quantidade Mínima de Caracteres
        [MaxLength(200, ErrorMessage = "A quantidade máxima de caracter não pode ser superior a {1} caracteres.")]
        /// *** Validação de Quantidade Máxima de Caracteres
        [Required(ErrorMessage = "Por favor, Digite o Endereço do Sócio.")]
        /// *** Validação de Campo Obrigatório
        /// *** Atributo Endereço do Sócio
        public string Endereco { get; set; }
    }
}
