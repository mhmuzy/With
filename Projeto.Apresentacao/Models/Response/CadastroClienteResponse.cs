using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto.Infra.Data.Entities;

namespace Projeto.Apresentacao.Models.Response
{
    public class CadastroClienteResponse
        /// *** Criação da Model de Cadastro de Cliente Response
    {
        public int SatusCode { get; set; }
        /// <summary>
        ///  Atributo Status Code
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Atributo Mensagem
        /// </summary>
        public Cliente Data { get; set; }
        /// *** Atributo Dados
        }
}
