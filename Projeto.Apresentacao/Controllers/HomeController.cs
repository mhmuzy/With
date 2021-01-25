using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Apresentacao.Repositories;
using Microsoft.AspNetCore.Authorization;
using Projeto.Apresentacao.Configurations;

namespace Projeto.Apresentacao.Controllers
{
    [Route("v1/account")]
    [ApiController]
    public class HomeController : ControllerBase
    {
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

            user.Password = "";
            return new
            {
                user = user,
                token = AppSettings.Secret
            };
        }
    }
}
