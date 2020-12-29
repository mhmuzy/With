using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto.Infra.Data.Entities;

namespace Projeto.Apresentacao.Models.Response
{
    public class ConsultaFornecedorResponse
        /// *** Criação da Model de Consulta de Fornecedor Response
    {
        public int StatusCode { get; set; }
        /// <summary>
        /// Atributo Status do Código
        /// </summary>
        public List<Fornecedor> Data { get; set; }
        /// *** Atributo Dados
    }
}
