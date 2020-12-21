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
    public class SocioController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CadastroSocioResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post(CadastroSocioRequest request)
        {
            var entity = new Socios
            {
                Matricula = new Random().Next(999, 999999),
                Nome = request.Nome,
                Telefone = request.Telefone,
                Celular = request.Celular,
                Cpf = request.Cpf,
                Email = request.Email,
                Endereco = request.Endereco
            };

            var response = new CadastroSocioResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Message = "Sócio Cadastrado Com Sucesso.",
                Data = entity
            };

            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EdicaoSocioResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put(EdicaoSocioRequest request)
        {
            var response = new EdicaoSocioResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Message = "Sócio Atualizado Com Sucesso."
            };

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExclusaoSocioResponse))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            var response = new ExclusaoSocioResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Sócio Excluído Com Sucesso."
            };

            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConsultaSocioResponse))]
        public IActionResult GetAll()
        {
            var response = new ConsultaSocioResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Data = new List<Socios>()
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConsultaSocioResponse))]
        public IActionResult GetById(int id)
        {
            var response = new ConsultaSocioResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Data = new List<Socios>()
            };

            return Ok(response);
        }
    }
}
