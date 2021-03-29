using Anuncios.Application.DTO;
using Anuncios.Application.Interfaces;
using Anuncios.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Anuncios.Service.API.Controllers
{
    [Route("[Controller]")]
    public class BaseController<Entity, EntityDTO> : Controller where Entity : Base where EntityDTO : BaseDTO
    {
        private readonly IAppServiceBase<Entity, EntityDTO> app;

        public BaseController(IAppServiceBase<Entity, EntityDTO> app)
        {
            this.app = app;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(app.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(app.GetById(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] EntityDTO entityDTO)
        {
            try
            {
                if (entityDTO == null)
                {
                    return NotFound();
                }

                app.Add(entityDTO);
                return Ok("Cadastro inserido com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] EntityDTO entityDTO)
        {
            try
            {
                if (entityDTO == null)
                {
                    return NotFound();
                }

                app.Update(entityDTO);
                return Ok("Cadastro atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] EntityDTO entityDTO)
        {
            try
            {
                if (entityDTO == null)
                {
                    return NotFound();
                }

                app.Update(entityDTO);
                return Ok("Cadastro removido com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}