using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto.Entidades; /// <summary>
/// Importando
/// </summary>

namespace Projeto.Apresentacao.Models.Response
{
    public class ConsultaClienteResponse
        /// *** Criação da Model de Consulta de Cliente Response
    {
        public int StatusCode { get; set; }
        /// <summary>
        /// Atributo Status Code
        /// </summary>
        public List<Clientes> Data { get; set; }
        /// *** Atributo Dados
    }
}
