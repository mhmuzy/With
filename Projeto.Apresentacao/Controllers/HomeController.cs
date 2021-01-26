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

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]UserEntity entity)
        {
            var user = UserRepository.Get(entity.Username, entity.Password);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = new TokenService();
            token.GenerateToken(entity);
            var entityCliente = new Cliente
            {
                Nome = "Teste 29",
                Cpf = "565.630.170-29",
                Telefone = "(21)2123-4568",
                Celular = "(21)99123-4568",
                Email = "mhmuzyteste857@gmail.com",
                Endereco = "Teste 29",
                FormaPagamento = 1
            };

            clienteRepository.Create(entityCliente);
            user.Password = "";
            return new
            {
                user = user,
                token = "Correção Realizadacom sucesso."
            };
        }
    }
}
