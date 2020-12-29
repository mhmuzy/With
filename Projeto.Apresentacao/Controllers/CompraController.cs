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
using Projeto.Repositories;
using Projeto.Infra.Data.Contracts;

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CadastroCompraResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post(CadastroCompraRequest request)
        {
            var entity = new Compra
            {
                CodCompra = new Random().Next(999, 999999),
                DataCompra = DateTime.Now,
                Cliente = request.Cliente,
                Produto = request.Produto
            };

            compraRepository.Create(entity);

            var response = new CadastroCompraResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Message = "Compra Cadastrada Com Sucesso.",
                Data = entity
            };

            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EdicaoCompraResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put(EdicaoCompraRequest request)
        {
            var entity = compraRepository.GetById(request.CodCompra);

            if (entity == null)
                return UnprocessableEntity();

            entity.Produto.CodProduto = request.Produto.CodProduto;
            entity.Cliente.CodCliente = request.Cliente.CodCliente;
            entity.DataCompra = DateTime.Now;

            compraRepository.Update(entity);

            var response = new EdicaoCompraResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Message = "Compra Atualizada Com Sucesso.",
                Data = entity
            };

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExclusaoCompraResponse))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            try
            {

                var entity = compraRepository.GetById(id);

                if (entity == null)
                    return UnprocessableEntity();

                compraRepository.Delete(entity);


            var response = new ExclusaoCompraResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Message = "Compra Excluída Com Sucesso.",
                Data = entity
            };

            return Ok(response);

            }
            catch (Exception)
            {

                return Ok("A compra está vinculada com um cliente ou algum produto cadastrado.");
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConsultaCompraResponse))]
        public IActionResult GetAll()
        {
            var response = new ConsultaCompraResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Data = compraRepository.GetAll()
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ConsultaCompraResponse))]
        public IActionResult GetById(int id)
        {
            var response = new ConsultaCompraResponse
            { 
                StatusCode = StatusCodes.Status200OK,
                Data = new List<Compra>()
            };

            response.Data.Add(compraRepository.GetById(id));

            return Ok(response);
        }
    }
}
