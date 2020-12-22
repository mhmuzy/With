using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Apresentacao.Models.Request;
using Projeto.Apresentacao.Models.Response;
using Projeto.Entidades;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using Projeto.Repositories;

namespace Projeto.Apresentacao.Controllers
{
    [Authorize]
    [EnableCors("DefaultPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class FornecimentoController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CadastroFornecimentoResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post(CadastroFornecimentoRequest request)
        {
            var entity = new Fornecimento
            { 
                CodFornecimento = new Random().Next(999, 999999),
                DataFornecimento = new DateTime(),
                Fornecedor = request.Fornecedor,
                Produto = request.Produto
            };

            var response = new CadastroFornecimentoResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Fornecimento Cadastrado Com Sucesso.",
                Data = entity
            };

            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EdicaoFornecimentoResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put(EdicaoFornecimentoRequest request)
        {
            var response = new EdicaoFornecimentoResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Message = "Fornecimento Ataulizado Com Sucesso."
            };

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExclusaoFornecimentoResponse))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            var response = new ExclusaoFornecimentoResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Message = "Fornecimento Excluído Com Sucesso."
            };

            return Ok(response);
        }

        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConsultaFornecedorResponse))]
        //public IActionResult GetAll()
        //{
            
        //}
    }
}
