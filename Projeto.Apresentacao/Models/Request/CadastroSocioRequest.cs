using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; /// <summary>
/// Importando
/// </summary>


namespace Projeto.Apresentacao.Models.Request
{
    public class CadastroSocioRequest
        /// *** Criação da Model Cadastro de Sócio Request
    {
        [MinLength(10, ErrorMessage = "A quantidade mínima de caracter não pode ser inferior a {1} caracteres.")]
        /// *** Validação da Quantidade Mínima de Carateres Permitida
        [MaxLength(80, ErrorMessage = "A quantidade máxima de caracter não pode ser superior a {1} caracteres.")]
        /// *** Validação da Quantidade Máxima de Caracteres Permitida
        [Required(ErrorMessage = "Por favor, digita o nome do Produto.")]
        /// *** Validação de Campo Obrigatório
        /// *** Atributo Nome do Sócio
        public string Nome { get; set; }

        [MinLength(16, ErrorMessage = "Formato de Telefone inválido.")]
        /// *** Validação de Quantidade Mínima de Caracteres que são Permitidos
        [MaxLength(16, ErrorMessage = "Formato de Telefone inválido.")]
        //// *** Validação de Quantidade Máxima de Caracteres que são Permitidos
        /// *** Atributo Telefone do Sócio
        public string Telefone { get; set; }

        [MinLength(17, ErrorMessage = "Formato de Celular inválido.")]
        /// *** Validação de Quantidade Mínima de Caracteres Permitida
        [MaxLength(17, ErrorMessage = "Formato de Celular inválido.")]
        /// *** Validação de Quantidade Máxima de Caracteres Permitida
        /// *** Atributo Celular do Sócio
        public string Celular { get; set; }

        [MinLength(14, ErrorMessage = "Formato de Cpf Inválido.")]
        /// *** Validação do Formato de Cpf
        [MaxLength(14, ErrorMessage = "Formato de Cpf Inválido.")]
        /// *** Validação do Formato de Cpf
        [Required(ErrorMessage = "Por favor, Digite o Cpf do Sócio.")]
        /// *** Validação Informando que é Campo Obrigatório
        /// *** Atributo Cpf do Sócio
        public string Cpf { get; set; }

        [EmailAddress(ErrorMessage = "E - mail inválido.")]
        /// *** Validação Informando Se o E - mail do Sócio está certo ou não
        [Required(ErrorMessage = "Por favor, Digite o e - mail do Sócio")]
        /// *** Validação de Campo Obrigatório
        /// *** Atributo E - mail do Sócio
        public string Email { get; set; }

        [MinLength(20, ErrorMessage = "A quantidade mínima de caracter é de {1} caracteres.")]
        /// *** Validação da Quantidade Mínima permitida de Caracter 
        [MaxLength(200, ErrorMessage = "A quantidade máxima de caracter é de {1} caracteres.")]
        /// *** Validação da Quantidade Máxima permitida de Caracter
        [Required(ErrorMessage = "Por favor, Digite o Endereço do Sócio.")]
        /// *** Validação de Campo Obrigatório
        /// *** Atributo Endereço do Sócio
        public string Endereco { get; set; }
    }
}
