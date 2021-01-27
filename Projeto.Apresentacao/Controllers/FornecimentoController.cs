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
    public class FornecimentoController : ControllerBase
    {
        private readonly IFornecimentoRepository fornecimentoRepository;

        public FornecimentoController(IFornecimentoRepository fornecimentoRepository)
        {
            this.fornecimentoRepository = fornecimentoRepository;
        }

        [HttpPost]
        [Route("Cadastrar Fornecimento")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Post([FromBody] CadastroFornecimentoRequest request)
        {

            UserEntity entity = new UserEntity();
            entity.Username = "marcio.freitas";
            entity.Password = "1234";

            var user = UserRepository.Get(entity.Username, entity.Password);


            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = new TokenService();
            token.GenerateToken(entity);

            var entityFornecimento = new Fornecimento
            {
                Fornecedor = request.Fornecedor,
                Produto = request.Produto,
                DataFornecimento = DateTime.Now
            };

            fornecimentoRepository.Create(entityFornecimento);
            user.Password = "";

            var response = new CadastroFornecimentoResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Fornecimento Cadastrado Com Sucesso.",
                Data = entityFornecimento
            };

            return new
            {
                user = user,
                message = response
            };
        }

        [HttpPut]
        [Route("Alterar Fornecimento")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Put([FromBody] EdicaoFornecimentoRequest request)
        {

            UserEntity entity = new UserEntity();
            entity.Username = "marcio.freitas";
            entity.Password = "1234";

            var user = UserRepository.Get(entity.Username, entity.Password);


            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = new TokenService();
            token.GenerateToken(entity);

            var entityFornecimento = fornecimentoRepository.GetById(request.CodFornecimento);

            if (entityFornecimento == null)
                return UnprocessableEntity();


            entityFornecimento.Fornecedor = request.Fornecedor;
            entityFornecimento.Produto = request.Produto;
            entityFornecimento.DataFornecimento = DateTime.Now;


            fornecimentoRepository.Update(entityFornecimento);
            user.Password = "";

            var response = new EdicaoFornecimentoResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Fornecimento Atualizado Com Sucesso.",
                Data = entityFornecimento
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
            var entityFornecimento = fornecimentoRepository.GetById(id);

            if (entityFornecimento == null)
                return UnprocessableEntity();

            fornecimentoRepository.Delete(entityFornecimento);

            var response = new ExclusaoFornecimentoResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Fornecimento Excluído Com Sucesso.",
                Data = entityFornecimento
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

            var response = new ConsultaFornecimentoResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Data = fornecimentoRepository.GetAll()
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

            var response = new ConsultaFornecimentoResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Data = new List<Fornecimento>()
            };

            response.Data.Add(fornecimentoRepository.GetById(id));

            return new
            {
                user = user,
                message = response
            };
        }
    }
}
