using Anuncios.Application.DTO;
using Anuncios.Application.Interfaces;
using Anuncios.Domain.Entities;
using Anuncios.Service.API.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anuncios.Service.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly IAppServiceCliente app;
        public class ClienteDTOAuthenticate
        {
            public string Email { get; set; }
            public string Senha { get; set; }
        }
        public ClienteController(IAppServiceCliente app)
        {
            this.app = app;
        }

        [HttpGet]
        [Authorize]
        [Route("Listar")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(app.GetAll());
        }

        [HttpGet]
        [Authorize]
        [Route("BuscarPorId")]
        public ActionResult<string> Get(int id)
        {
            return Ok(app.GetById(id));
        }

        [HttpPost]
        [Authorize]
        [Route("Cadastrar")]
        public ActionResult Post([FromBody] ClienteDTO clienteDTO)
        {
            try
            {
                if (clienteDTO == null)
                {
                    return NotFound();
                }

                app.Add(clienteDTO);
                return Ok("Cliente inserido com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [Authorize]
        [Route("Atualizar")]
        public ActionResult Put([FromBody] ClienteDTO clienteDTO)
        {
            try
            {
                if (clienteDTO == null)
                {
                    return NotFound();
                }

                app.Update(clienteDTO);
                return Ok("Cliente atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("Excluir")]
        public ActionResult Delete(int Id)
        {
            try
            {
                var clienteDTO = app.GetById(Id);
                if (clienteDTO == null)
                {
                    return NotFound("Cliente não encontrado!");
                }

                app.Remove(clienteDTO);
                return Ok("Cliente removido com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] ClienteDTOAuthenticate clienteDTO)
        {
            var clienteDTOLogin = app.GetAll().FirstOrDefault(c => c.Email.Equals(clienteDTO.Email) && c.Senha.Equals(clienteDTO.Senha));
            if(clienteDTOLogin == null)
            {
                return NotFound(new { message = "E-mail ou senha inválidos!" });
            }
            var token = TokenService.GenerateToken(clienteDTOLogin);
            clienteDTOLogin.Senha = "********";
            return new { cliente = clienteDTOLogin, token = token };
        }

        [HttpGet]
        [Authorize]
        [Route("Autenticado")]
        public string Authenticated() => String.Format("Autenticado - {0}!", User.Identity.Name);

    }
}