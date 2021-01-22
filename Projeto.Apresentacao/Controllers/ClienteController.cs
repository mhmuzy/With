﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Apresentacao.Models.Request;
using Projeto.Apresentacao.Models.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using Projeto.Apresentacao.Repositories;
using Projeto.Infra.Data.Contracts;
using Projeto.Infra.Data.Entities;

namespace Projeto.Apresentacao.Controllers
{
    [Authorize]
    [EnableCors("DefaultPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CadastroClienteResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post(CadastroClienteRequest request)
        {
            var entity = new Cliente
            {
                CodCliente = new Random().Next(999, 999999),
                Nome = request.Nome,
                Cpf = request.Cpf,
                Telefone = request.Telefone,
                Celular = request.Celular,
                Email = request.Email,
                Endereco = request.Endereco,
                FormaPagamento = request.FormaPagamento
            };

            clienteRepository.Create(entity);

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
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put(EdicaoClienteRequest request)
        {
            var entity = clienteRepository.GetById(request.CodCliente);

            if (entity == null)
                return UnprocessableEntity();

            entity.Nome = request.Nome;
            entity.Cpf = request.Cpf;
            entity.Telefone = request.Telefone;
            entity.Celular = request.Celular;
            entity.Email = request.Email;
            entity.Endereco = request.Endereco;
            entity.FormaPagamento = request.FormaPagamento;

            clienteRepository.Update(entity);

            var response = new EdicaoClienteResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Cliente Atualizado Com Sucesso.",
                Data = entity
            };

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExclusaoClienteResponse))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            try
            {

            
            var entity = clienteRepository.GetById(id);

            if (entity == null)
                return UnprocessableEntity();

                clienteRepository.Delete(entity);

            var response = new ExclusaoClienteResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Message = "Cliente Excluído Com Sucesso.",
                Data = entity
            };

            return Ok(response);

            }
            catch (Exception)
            {

                return Ok("Cliente tem um ou mais Produtos cadastrados na compra.");
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConsultaClienteResponse))]
        public IActionResult GetAll()
        {
            var response = new ConsultaClienteResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Data = clienteRepository.GetAll()
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
                Data = new List<Cliente>()
            };

            response.Data.Add(clienteRepository.GetById(id));

            return Ok(response);
        }

        [HttpGet("{cpf}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConsultaClienteResponse))]
        public IActionResult GetByCpf(string cpf)
        {
            var response = new ConsultaClienteResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Data = new List<Cliente>()
            };

            response.Data.Add(clienteRepository.GetByCpf(cpf));

            return Ok(response);
        }
    }
}
