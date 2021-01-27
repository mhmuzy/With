using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Apresentacao.Repositories;
using Microsoft.AspNetCore.Authorization;
using Projeto.Apresentacao.Configurations;
using Projeto.Infra.Data.Entities;
using Projeto.Infra.Data.Contracts;
using Projeto.Apresentacao.Models.Response;

namespace Projeto.Apresentacao.Controllers
{
    [Route("v1/account")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IClienteRepository clienteRepository;

        public HomeController(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
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
    }
}
