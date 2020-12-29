using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto.Infra.Data.Entities;

namespace Projeto.Apresentacao.Models.Response
{
    public class ExclusaoFornecedorResponse
        /// *** Criação da Model de Exclusão de Fornecedores Response
    {
        public int StatusCode { get; set; }
        /// <summary>
        /// Atributo Status Code
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Atributo Mensagem
        /// </summary>
        public Fornecedor Data { get; set; }
        /// *** Atributo Dados
    }
}
