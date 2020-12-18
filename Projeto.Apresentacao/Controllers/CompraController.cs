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

namespace Projeto.Apresentacao.Controllers
{
    [Authorize]
    [EnableCors("DefaultPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CadastroCompraResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post(CadastroCompraRequest request)
        {
            var entity = new Compra
            {
                CodCompra = new Random().Next(999, 999999),
                DataCompra = new DateTime(),
                Cliente = request.Cliente,
                Produto = request.Produto
            };

            var response = new CadastroCompraResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Message = "Compra Cadastrada Com Sucesso.",
                Data = entity
            };

            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EdicaoCompraResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put(EdicaoCompraRequest request)
        {
            var response = new EdicaoCompraResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Message = "Compra Atualizada Com Sucesso."
            };

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExclusaoCompraResponse))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            var response = new ExclusaoCompraResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Message = "Compra Excluída Com Sucesso."
            };

            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConsultaCompraResponse))]
        public IActionResult GetAll()
        {
            var response = new ConsultaCompraResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Data = new List<Compra>()
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConsultaCompraResponse))]
        public IActionResult GetById(int id)
        {
            var response = new ConsultaCompraResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Data = new List<Compra>()
            };

            return Ok(response);
        }
    }
}
