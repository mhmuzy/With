using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto.Infra.Data.Entities;

namespace Projeto.Apresentacao.Models.Response
{
    public class CadastroSocioResponse
        /// *** Criação da Model de Cadastro de Sócio Response
    {
        public int StatusCode { get; set; }
        /// <summary>
        /// Atributo Status Code
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Atributo Mensagem
        /// </summary>
        public Socio Data { get; set; }
        /// *** Atributo Dados
    }
}
