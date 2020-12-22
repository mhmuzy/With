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
    public class ClienteController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CadastroClienteResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post(CadastroClienteRequest request)
        {
            var entity = new Clientes
            {
                CodCliente = new Random().Next(999, 999999),
                Nome = request.Nome,
                Telefone = request.Telefone,
                Produto = request.Produto,
                Celular = request.Celular,
                Cpf = request.Cpf,
                Email = request.Email,
                Endereco = request.Endereco
            };

            var response = new CadastroClienteResponse
            { 
                SatusCode = StatusCodes.Status200OK,
                Message = "Cliente Cadastrado Com Sucesso.",
                Data = entity
            };

            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EdicaoClienteResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put(EdicaoClienteRequest request)
        {

            var response = new EdicaoClienteResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Cliente Atualizado Com Sucesso."
            };

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExclusaoClienteResponse))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            var response = new ExclusaoClienteResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Message = "Cliente Excluído Com Sucesso."
            };

            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConsultaClienteResponse))]
        public IActionResult GetAll()
        {
            var response = new ConsultaClienteResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Data = new List<Clientes>()
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConsultaClienteResponse))]
        public IActionResult GetById(int id)
        {
            var response = new ConsultaClienteResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Data = new List<Clientes>()
            };

            return Ok(response);
        }
    }
}
