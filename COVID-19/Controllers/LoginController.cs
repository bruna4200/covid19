using covid19.Services;
using covid19.Models;
using covid19.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace covid19.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private LoginRepository _repository;
        public LoginController()
        {
            _repository = new LoginRepository();
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("Autenticacao")]
        public async Task<ActionResult<dynamic>> Autenticacao(Login login)
        {
            var usuario = _repository.GetLogin(login);
            if (usuario == null)
                return NotFound("Esse usuário e/ou senha não existem ou inválidos");


            var token = TokenService.GenerateToken(usuario);
            login.senha = "";
            return new
            {
                usuario = usuario,
                token = token
            };
        }
    }
}
