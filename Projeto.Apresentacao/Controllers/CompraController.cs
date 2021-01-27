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
    public class CompraController : ControllerBase
    {

        private readonly ICompraRepository compraRepository;

        public CompraController(ICompraRepository compraRepository)
        {
            this.compraRepository = compraRepository;
        }

        [HttpPost]
        [Route("Cadastrar Compra")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Post([FromBody] CadastroCompraRequest request)
        {

            UserEntity entity = new UserEntity();
            entity.Username = "marcio.freitas";
            entity.Password = "1234";

            var user = UserRepository.Get(entity.Username, entity.Password);


            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = new TokenService();
            token.GenerateToken(entity);

            var entityCompra = new Compra
            {
                Cliente = request.Cliente,
                Produto = request.Produto
            };

            compraRepository.Create(entityCompra);
            user.Password = "";

            var response = new CadastroCompraResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Cliente Cadastrado Com Sucesso.",
                Data = entityCompra
            };


            return new
            {
                user = user,
                message = response
            };
        }
        [HttpPut]
        [Route("Alterar Compra")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Put([FromBody] EdicaoCompraRequest request)
        {

            UserEntity entity = new UserEntity();
            entity.Username = "marcio.freitas";
            entity.Password = "1234";

            var user = UserRepository.Get(entity.Username, entity.Password);


            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = new TokenService();
            token.GenerateToken(entity);

            var entityCompra = compraRepository.GetById(request.CodCompra);

            if (entityCompra == null)
                return UnprocessableEntity();


            entityCompra.Cliente = request.Cliente;
            entityCompra.Produto = request.Produto;


            compraRepository.Update(entityCompra);
            user.Password = "";

            var response = new EdicaoCompraResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Compra Atualizada Com Sucesso.",
                Data = entityCompra
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
            var entityCompra = compraRepository.GetById(id);

            if (entityCompra == null)
                return UnprocessableEntity();

            compraRepository.Delete(entityCompra);

            var response = new ExclusaoCompraResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Compra Excluída Com Sucesso.",
                Data = entityCompra
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

            var response = new ConsultaCompraResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Data = compraRepository.GetAll()
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

            var response = new ConsultaCompraResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Data = new List<Compra>()
            };

            response.Data.Add(compraRepository.GetById(id));

            return new
            {
                user = user,
                message = response
            };
        }
    }
}
