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
using Projeto.Apresentacao.Configurations;

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
        [Route("Cadastrar Fornecedor")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Post([FromBody] CadastroFornecedorRequest request)
        {

            UserEntity entity = new UserEntity();
            entity.Username = "marcio.freitas";
            entity.Password = "1234";

            var user = UserRepository.Get(entity.Username, entity.Password);


            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = new TokenService();
            token.GenerateToken(entity);

            var entityFornecedor = new Fornecedor
            {
                Nome = request.Nome,
                Celular = request.Celular,
                Cnpj = request.Cnpj,
                Cpf = request.Cpf,
                Email = request.Email,
                Telefone = request.Telefone,
                Endereco = request.Endereco
            };

            fornecedorRepository.Create(entityFornecedor);
            user.Password = "";

            var response = new CadastroFornecedorResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Fornecedor Cadastrado Com Sucesso.",
                Data = entityFornecedor
            };


            return new
            {
                user = user,
                message = response
            };
        }

        [HttpPut]
        [Route("Alterar Fornecedor")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Put([FromBody] EdicaoFornecedorRequest request)
        {

            UserEntity entity = new UserEntity();
            entity.Username = "marcio.freitas";
            entity.Password = "1234";

            var user = UserRepository.Get(entity.Username, entity.Password);


            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = new TokenService();
            token.GenerateToken(entity);

            var entityFornecedor = fornecedorRepository.GetById(request.CodFornecedor);

            if (entityFornecedor == null)
                return UnprocessableEntity();


            entityFornecedor.Nome = request.Nome;
            entityFornecedor.Telefone = request.Telefone;
            entityFornecedor.Cpf = request.Cpf;
            entityFornecedor.Email = request.Email;
            entityFornecedor.Endereco = request.Endereco;

            fornecedorRepository.Update(entityFornecedor);
            user.Password = "";

            var response = new EdicaoFornecedorResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Compra Atualizada Com Sucesso.",
                Data = entityFornecedor
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
            var entityFornecedor = fornecedorRepository.GetById(id);

            if (entityFornecedor == null)
                return UnprocessableEntity();

            fornecedorRepository.Delete(entityFornecedor);

            var response = new ExclusaoFornecedorResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Fornecedor Excluído Com Sucesso.",
                Data = entityFornecedor
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

            var response = new ConsultaFornecedorResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Data = fornecedorRepository.GetAll()
            };
            return new
            {
                user = user,
                message = response
            };
        }

        [HttpGet("{id}")]
        //[Route("Excluir Cliente")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> GetById(int id)
        {

            UserEntity entity = new UserEntity();
            entity.Username = "marcio.freitas";
            entity.Password = "1234";

            var user = UserRepository.Get(entity.Username, entity.Password);


            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = new TokenService();
            token.GenerateToken(entity);

            var response = new ConsultaFornecedorResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Data = new List<Fornecedor>()
            };

            response.Data.Add(fornecedorRepository.GetById(id));

            return new
            {
                user = user,
                message = response
            };
        }

        //[HttpGet("{cpf}")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConsultaFornecedorResponse))]
        //public IActionResult GetByCpf(string cpf)
        //{
        //    var response = new ConsultaFornecedorResponse
        //    { 
        //        StatusCode = StatusCodes.Status200OK,
        //        Data = new List<Fornecedor>()
        //    };

        //    response.Data.Add(fornecedorRepository.GetByCpf(cpf));

        //    return Ok(response);
        //}

        //[HttpGet("{cnpj}")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConsultaFornecedorResponse))]
        //public IActionResult GetByCnpj(string cnpj)
        //{
        //    var response = new ConsultaFornecedorResponse
        //    {
        //         StatusCode = StatusCodes.Status200OK,
        //         Data = new List<Fornecedor>()
        //    };

        //    response.Data.Add(fornecedorRepository.GetByCnpj(cnpj));

        //    return Ok(response);
        //}
    }
}
