using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto.Entidades; /// <summary>
/// Importando
/// </summary>

namespace Projeto.Apresentacao.Models.Response
{
    public class ConsultaFornecedorResponse
        /// *** Criação da Model de Consulta de Fornecedor Response
    {
        public int StatusCode { get; set; }
        /// <summary>
        /// Atributo Status do Código
        /// </summary>
        public List<Fornecedores> Data { get; set; }
        /// *** Atributo Dados
    }
}
