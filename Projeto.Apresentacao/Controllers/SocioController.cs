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
    public class SocioController : ControllerBase
    {
        private readonly ISocioRepository socioRepository;

        public SocioController(ISocioRepository socioRepository)
        {
            this.socioRepository = socioRepository;
        }

        [HttpPost]
        [Route("Cadastrar Sócio")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Post([FromBody] CadastroSocioRequest request)
        {

            UserEntity entity = new UserEntity();
            entity.Username = "marcio.freitas";
            entity.Password = "1234";

            var user = UserRepository.Get(entity.Username, entity.Password);


            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = new TokenService();
            token.GenerateToken(entity);

            var entitySocio = new Socio
            {
                Nome = request.Nome,
                Telefone = request.Telefone,
                Celular = request.Celular,
                Cpf = request.Cpf,
                Email = request.Email,
                Endereco = request.Endereco
            };

            socioRepository.Create(entitySocio);
            user.Password = "";

            var response = new CadastroSocioResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Sócio Cadastrado Com Sucesso.",
                Data = entitySocio
            };

            return new
            {
                user = user,
                message = response
            };
        }

        [HttpPut]
        [Route("Alterar Sócio")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Put([FromBody] EdicaoSocioRequest request)
        {

            UserEntity entity = new UserEntity();
            entity.Username = "marcio.freitas";
            entity.Password = "1234";

            var user = UserRepository.Get(entity.Username, entity.Password);


            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = new TokenService();
            token.GenerateToken(entity);

            var entitySocio = socioRepository.GetById(request.Matricula);

            if (entitySocio == null)
                return UnprocessableEntity();


            entitySocio.Nome = request.Nome;
            entitySocio.Telefone = request.Telefone;
            entitySocio.Celular = request.Celular;
            entitySocio.Cpf = request.Cpf;
            entitySocio.Email = request.Email;
            entitySocio.Endereco = request.Endereco;

            socioRepository.Update(entitySocio);
            user.Password = "";

            var response = new EdicaoSocioResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Sócio Atualizado Com Sucesso.",
                Data = entitySocio
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
            var entitySocio = socioRepository.GetById(id);

            if (entitySocio == null)
                return UnprocessableEntity();

            socioRepository.Delete(entitySocio);

            var response = new ExclusaoSocioResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Sócio Excluído Com Sucesso.",
                Data = entitySocio
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

            var response = new ConsultaSocioResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Data = socioRepository.GetAll().ToList()
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

            var response = new ConsultaSocioResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Data = new List<Socio>()
            };

            response.Data.Add(socioRepository.GetById(id));

            return new
            {
                user = user,
                message = response
            };
        }

        //[HttpGet("{cpf}")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConsultaSocioResponse))]
        //public IActionResult GetByCpf(string cpf)
        //{
        //    var response = new ConsultaSocioResponse
        //    { 
        //        StatusCode = StatusCodes.Status200OK,
        //        Data = new List<Socio>()
        //    };

        //    response.Data.Add(socioRepository.GetByCpf(cpf));

        //    return Ok(response);
        //}
    }
}
