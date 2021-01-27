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
using Projeto.Apresentacao.Models.Request;

namespace Projeto.Apresentacao.Controllers
{
    [Route("v1/account")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IFornecimentoRepository fornecimentoRepository;

        public HomeController(IFornecimentoRepository fornecimentoRepository)
        {
            this.fornecimentoRepository = fornecimentoRepository;
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
    }
}
