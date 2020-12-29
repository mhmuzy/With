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
using Projeto.Repositories;
using Projeto.Infra.Data.Contracts;

namespace Projeto.Apresentacao.Controllers
{
    [Authorize]
    [EnableCors("DefaultPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorRepository fornecedorRepository;

        public FornecedorController(IFornecedorRepository fornecedorRepository)
        {
            this.fornecedorRepository = fornecedorRepository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CadastroFornecedorResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post(CadastroFornecedorRequest request)
        {
            var entity = new Fornecedor
            { 
                CodFornecedor = new Random().Next(999, 999999),
                Nome = request.Nome,
                Celular = request.Celular,
                Telefone = request.Telefone,
                Cnpj = request.Cnpj,
                Cpf = request.Cpf,
                Email = request.Email,
                Endereco = request.Endereco
            };

            fornecedorRepository.Create(entity);

            var response = new CadastroFornecedorResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Message = "Fornecedor Cadastrado Com Sucesso.",
                Data = entity
            };

            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EdicaoFornecedorResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put(EdicaoFornecedorRequest request)
        {
            var entity = fornecedorRepository.GetById(request.CodFornecedor);

            if (entity == null)
                return UnprocessableEntity();

            entity.Nome = request.Nome;
            entity.Telefone = request.Telefone;
            entity.Celular = request.Celular;
            entity.Cnpj = request.Cnpj;
            entity.Cpf = request.Cpf;
            entity.Email = request.Email;
            entity.Endereco = request.Endereco;

            fornecedorRepository.Update(entity);

            var response = new EdicaoFornecedorResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Message = "Fornecedor Atualizado Com Sucesso.",
                Data = entity
            };

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExclusaoFornecedorResponse))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            var entity = fornecedorRepository.GetById(id);

            if (entity == null)
                return UnprocessableEntity();

            fornecedorRepository.Delete(entity);

            var response = new ExclusaoFornecedorResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Message = "Fornecedor Excluído Com Sucesso.",
                Data = entity
            };

            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConsultaFornecedorResponse))]
        public IActionResult GetAll()
        {
            var response = new ConsultaFornecedorResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Data = fornecedorRepository.GetAll()
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConsultaFornecedorResponse))]
        public IActionResult GetById(int id)
        {
            var response = new ConsultaFornecedorResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Data = new List<Fornecedor>()
            };

            response.Data.Add(fornecedorRepository.GetById(id));

            return Ok(response);
        }

        [HttpGet("{cpf}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConsultaFornecedorResponse))]
        public IActionResult GetByCpf(string cpf)
        {
            var response = new ConsultaFornecedorResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Data = new List<Fornecedor>()
            };

            response.Data.Add(fornecedorRepository.GetByCpf(cpf));

            return Ok(response);
        }

        [HttpGet("{cnpj}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConsultaFornecedorResponse))]
        public IActionResult GetByCnpj(string cnpj)
        {
            var response = new ConsultaFornecedorResponse
            {
                 StatusCode = StatusCodes.Status200OK,
                 Data = new List<Fornecedor>()
            };

            response.Data.Add(fornecedorRepository.GetByCnpj(cnpj));

            return Ok(response);
        }
    }
}
