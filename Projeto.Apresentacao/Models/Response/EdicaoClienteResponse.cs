using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto.Entidades; /// <summary>
/// Importando
/// </summary>

namespace Projeto.Apresentacao.Models.Response
{
    public class EdicaoClienteResponse
        /// *** Criação da Model Edição de Cliente Response
    {
        public int StatusCode { get; set; }
        /// <summary>
        /// Atributo Status Code
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Atributo Mensagem
        /// </summary>
        public Clientes Data { get; set; }
        /// *** Atributo Dados
    }
}
