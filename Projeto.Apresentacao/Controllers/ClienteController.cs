using System;
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
using Projeto.Apresentacao.Configurations;

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
        [Route("Cadastrar Cliente")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Post([FromBody] CadastroClienteRequest request)
        {

            UserEntity entity = new UserEntity();
            entity.Username = "marcio.freitas";
            entity.Password = "1234";

            var user = UserRepository.Get(entity.Username, entity.Password);


            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = new TokenService();
            token.GenerateToken(entity);
            var entityCliente = new Cliente
            {
                Nome = request.Nome,
                Cpf = request.Cpf,
                Telefone = request.Telefone,
                Celular = request.Celular,
                Email = request.Email,
                Endereco = request.Endereco,
                FormaPagamento = request.FormaPagamento
            };

            clienteRepository.Create(entityCliente);
            user.Password = "";

            var response = new CadastroClienteResponse
            {
                SatusCode = StatusCodes.Status200OK,
                Message = "Cliente Cadastrado Com Sucesso.",
                Data = entityCliente
            };

            return new
            {
                user = user,
                message = response
            };
        }

        [HttpPut]
        [Route("Atualizar Cliente")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Put([FromBody] EdicaoClienteRequest request)
        {

            UserEntity entity = new UserEntity();
            entity.Username = "marcio.freitas";
            entity.Password = "1234";

            var user = UserRepository.Get(entity.Username, entity.Password);


            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = new TokenService();
            token.GenerateToken(entity);
            var entityCliente = clienteRepository.GetById(request.CodCliente);

            if (entityCliente == null)
                return UnprocessableEntity();

            entityCliente.Nome = request.Nome;
            entityCliente.Cpf = request.Cpf;
            entityCliente.Telefone = request.Telefone;
            entityCliente.Celular = request.Celular;
            entityCliente.Email = request.Email;
            entityCliente.Endereco = request.Endereco;
            entityCliente.FormaPagamento = request.FormaPagamento;

            clienteRepository.Update(entityCliente);

            var response = new EdicaoClienteResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Cliente Atualizado Com Sucesso.",
                Data = entityCliente
            };
            return new
            {
                user = user,
                message = response
            };
        }

        [HttpDelete("{id}")]
        //[Route("Excluir Cliente")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Delete(int id)
        {

            UserEntity entity = new UserEntity();
            entity.Username = "marcio.freitas";
            entity.Password = "1234";

            var user = UserRepository.Get(entity.Username, entity.Password);


            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = new TokenService();
            token.GenerateToken(entity);
            var entityCliente = clienteRepository.GetById(id);

            if (entityCliente == null)
                return UnprocessableEntity();

            clienteRepository.Delete(entityCliente);

            var response = new ExclusaoClienteResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Cliente Excluído Com Sucesso.",
                Data = entityCliente
            };
            return new
            {
                user = user,
                message = response
            };
        }

        [HttpGet]
        //[Route("Excluir Cliente")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> GetAll()
        {

            UserEntity entity = new UserEntity();
            entity.Username = "marcio.freitas";
            entity.Password = "1234";

            var user = UserRepository.Get(entity.Username, entity.Password);


            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = new TokenService();
            token.GenerateToken(entity);

            var response = new ConsultaClienteResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Data = clienteRepository.GetAll()
            };
            return new
            {
                user = user,
                message = response
            };
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
