using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http; 
using Microsoft.AspNetCore.Mvc;
using Projeto.Apresentacao.Models.Request; /// *** Importando
using Projeto.Apresentacao.Models.Response; /// *** Importando
using Projeto.Infra.Data.Entities;
using Microsoft.AspNetCore.Cors; /// *** Importando
using Microsoft.AspNetCore.Authorization; /// <summary>
using Projeto.Infra.Data.Contracts;
using Projeto.Apresentacao.Repositories;
using Projeto.Apresentacao.Configurations;

namespace Projeto.Apresentacao.Controllers
{
    [Authorize]
    [EnableCors("DefaultPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
        /// *** Criação da Controller Produto
    {
        private readonly IProdutoRepository produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        [HttpPost]
        [Route("Cadastrar Produto")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Post([FromBody] CadastroProdutoRequest request)
        {

            UserEntity entity = new UserEntity();
            entity.Username = "marcio.freitas";
            entity.Password = "1234";

            var user = UserRepository.Get(entity.Username, entity.Password);


            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = new TokenService();
            token.GenerateToken(entity);

            var entityProduto = new Produto
            {
                Fornecedor = request.Fornecedor,
                Nome = request.Nome,
                Preco = request.Preco,
                Descricao = request.Descricao,
                Estoque = request.Estoque
            };

            produtoRepository.Create(entityProduto);
            user.Password = "";

            var response = new CadastroProdutoResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Produto Cadastrado Com Sucesso.",
                Data = entityProduto
            };

            return new
            {
                user = user,
                message = response
            };
        }

        [HttpPut]
        [Route("Alterar Produto")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Put([FromBody] EdicaoProdutoRequest request)
        {

            UserEntity entity = new UserEntity();
            entity.Username = "marcio.freitas";
            entity.Password = "1234";

            var user = UserRepository.Get(entity.Username, entity.Password);


            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = new TokenService();
            token.GenerateToken(entity);

            var entityProduto = produtoRepository.GetById(request.CodProduto);

            if (entityProduto == null)
                return UnprocessableEntity();


            entityProduto.Nome = request.Nome;
            entityProduto.Preco = request.Preco;
            entityProduto.Descricao = request.Descricao;
            entityProduto.Estoque = request.Estoque;
            entityProduto.Fornecedor = request.Fornecedor;

            produtoRepository.Update(entityProduto);
            user.Password = "";

            var response = new EdicaoProdutoResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Produto Atualizado Com Sucesso.",
                Data = entityProduto
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
            var entityProduto = produtoRepository.GetById(id);

            if (entityProduto == null)
                return UnprocessableEntity();

            produtoRepository.Delete(entityProduto);

            var response = new ExclusaoProdutoResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Produto Excluído Com Sucesso.",
                Data = entityProduto
            };
            return new
            {
                user = user,
                message = response
            };
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConsultaProdutoResponse))]
        public IActionResult GetAll()
        {
            var response = new ConsultaProdutoResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Data = produtoRepository.GetAll()
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConsultaProdutoResponse))]
        public IActionResult GetById(int id)
        {
            var response = new ConsultaProdutoResponse
            {
                StatusCode = StatusCodes.Status200OK,
                Data = new List<Produto>()
            };

            response.Data.Add(produtoRepository.GetById(id));

            return Ok(response);
        }
    }
}
