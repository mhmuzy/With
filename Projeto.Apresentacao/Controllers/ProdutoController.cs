﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http; 
using Microsoft.AspNetCore.Mvc;
using Projeto.Apresentacao.Models.Request; /// *** Importando
using Projeto.Apresentacao.Models.Response; /// *** Importando
using Projeto.Entidades; /// *** Importando
using Microsoft.AspNetCore.Cors; /// *** Importando
using Microsoft.AspNetCore.Authorization; /// <summary>
///  Importando
/// </summary>

namespace Projeto.Apresentacao.Controllers
{
    [Authorize]
    [EnableCors("DefaultPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
        /// *** Criação da Controller Produto
    {
        [HttpPost]
        /// *** Método de Cadastro
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CadastroProdutoResponse))]
        /// *** Se Cadastrar Com Sucesso
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        /// *** Se Der Bug
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        /// *** Se Der Bug
        public IActionResult Post(CadastroProdutoRequest request)
            /// *** Criação do Método de Cadastro
        {
            var entity = new Produtos
            /// *** Criação da Entidade Produto
            {
                CodProduto = new Random().Next(999, 999999),
                /// *** Código do Produto Recebe um número aleatório
                Nome = request.Nome,
                /// *** Atributo Nome Recebe o dado Nome da Model
                Fornecedor = request.Fornecedor,
                /// *** Atributo Fornecedor Recebe o Dado Fornecedor da Model 
                Preco = request.Preco,
                /// *** Atributo Preço recebe o Dado Preço da Model 
                Descricao = request.Descricao
                /// *** Atributo Descrição Recebe o Dado Descrição da Model 
            };

            var response = new CadastroProdutoResponse
                /// *** Instância da Model Response Cadastro de Produto
            { 
                StatusCode = StatusCodes.Status200OK,
                /// *** Status Code Recebe 200
                Message = "Produto Cadastrado Com Sucesso.",
                /// *** Mensagem Recebe Produto Cadastrado Com Sucesso.
                Data = entity /// *** Dados Recebe a Entidade Produto
            };

            return Ok(response); /// *** Retorna a Model
        }

        [HttpPut]
        /// *** Criação da Alteração de Dados
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EdicaoProdutoResponse))]
        /// *** Se Rodar Com Sucesso
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        /// *** Se Der Bug
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        /// *** Se Der Bug
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        /// *** Se Der Bug
        public IActionResult Put(EdicaoProdutoRequest request)
            /// *** Criação do Endpoint
        {
            var response = new EdicaoProdutoResponse
            /// *** Instância da Model de Response de Edição de Produto
            { 
                StatusCode = StatusCodes.Status200OK,
                /// *** Status Code Vai Receber 200
                Message = "Produto Atualizado Com Sucesso."
                /// *** Mensagem Vai Receber Produto Atualizado Com Sucesso.
            };

            return Ok(response); /// *** Retrona a Model
        }

        [HttpDelete("{id}")]
        /// *** Criação da Exclusão
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExclusaoProdutoResponse))]
        /// *** Se o Programa Rodar Com Sucesso
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        /// *** Se Der Bug
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        /// *** Se Der Bug
        public IActionResult Delete(int id)
            /// *** Criação do Endpoint
        {
            var response = new ExclusaoProdutoResponse
            /// *** Instância da Model Response de Exclusão de Produto
            { 
                StatusCode = StatusCodes.Status200OK,
                /// *** Status Code Vai Receber 200
                Message = "Produto Excluído Com Suecsso."
                /// *** Mensagem Vai Receber Produto Excluído Com Sucesso.
            };

            return Ok(response); /// *** Retorna a Model
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConsultaProdutoResponse))]
        public IActionResult GetAll()
        {
            var response = new ConsultaProdutoResponse
            { 
                StatusCode = StatusCodes.Status200OK
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
                Data = new List<Produtos>()
            };

            return Ok(response);
        }
    }
}