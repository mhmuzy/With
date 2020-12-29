using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto.Infra.Data.Entities;

namespace Projeto.Apresentacao.Models.Response
{
    public class ConsultaCompraResponse
        /// *** Criação da Model de Consulta de Compra Response
    {
        public int StatusCode { get; set; }
        /// <summary>
        /// Atributo Status Code
        /// </summary>
        public List<Compra> Data { get; set; }
        /// *** Atributo Dados
    }
}
