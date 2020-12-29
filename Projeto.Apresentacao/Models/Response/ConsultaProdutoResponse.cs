using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto.Infra.Data.Entities;

namespace Projeto.Apresentacao.Models.Response
{
    public class ConsultaProdutoResponse
        /// *** Criação da Model Consulta de Produto Response
    {
        public int StatusCode { get; set; }
        /// <summary>
        /// Atributo Status Code
        /// </summary>
        public List<Produto> Data { get; set; }
        /// *** Atributo Dados
    }
}
