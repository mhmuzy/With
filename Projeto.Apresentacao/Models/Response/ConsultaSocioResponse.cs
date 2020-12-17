using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto.Entidades; /// <summary>
/// Importando
/// </summary>

namespace Projeto.Apresentacao.Models.Response
{
    public class ConsultaSocioResponse
        /// *** Criação da Model Consulta de Produto Response
    {
        public int StatusCode { get; set; }
        /// <summary>
        /// Atributo Status Code
        /// </summary>
        public List<Socios> Data { get; set; }
        /// *** Atributo Dados
    }
}
