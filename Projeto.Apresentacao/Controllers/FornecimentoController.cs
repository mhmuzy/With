using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Apresentacao.Models.Request;
using Projeto.Apresentacao.Models.Response;
using Projeto.Infra.Data.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using Projeto.Apresentacao.Repositories;
using Projeto.Infra.Data.Contracts;

namespace Projeto.Apresentacao.Controllers
{
    [Authorize]
    [EnableCors("DefaultPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class FornecimentoController : ControllerBase
    {
        private readonly IFornecimentoRepository fornecimentoRepository;

        public FornecimentoController(IFornecimentoRepository fornecimentoRepository)
        {
            this.fornecimentoRepository = fornecimentoRepository;
        }

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

            fornecimentoRepository.Create(entity);

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
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put(EdicaoFornecimentoRequest request)
        {
            var entity = fornecimentoRepository.GetById(request.CodFornecimento);

            if (entity == null)
                return UnprocessableEntity();

            entity.DataFornecimento = DateTime.Now;
            entity.Fornecedor = request.Fornecedor;
            entity.Produto = request.Produto;

            fornecimentoRepository.Update(entity);

            var response = new EdicaoFornecimentoResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Message = "Fornecimento Ataulizado Com Sucesso.",
                Data = entity
            };

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExclusaoFornecimentoResponse))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            try
            {

                var entity = fornecimentoRepository.GetById(id);

                if (entity == null)
                    return UnprocessableEntity();

                fornecimentoRepository.Delete(entity);

            var response = new ExclusaoFornecimentoResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Message = "Fornecimento Excluído Com Sucesso.",
                Data = entity
            };

            return Ok(response);


            }
            catch (Exception)
            {

                return Ok("A exclusão do forneciento não pode ser efetuada, pois pode ter algum fornecedor ou produto cadastrado.");
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConsultaFornecimentoResponse))]
        public IActionResult GetAll()
        {
            var response = new ConsultaFornecimentoResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Data = fornecimentoRepository.GetAll()
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConsultaFornecimentoResponse))]
        public IActionResult GetById(int id)
        {
            var response = new ConsultaFornecimentoResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Data = new List<Fornecimento>()
            };

            response.Data.Add(fornecimentoRepository.GetById(id));

            return Ok(response);
        }
    }
}
