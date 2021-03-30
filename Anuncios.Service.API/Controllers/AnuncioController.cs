using Anuncios.Application.DTO;
using Anuncios.Application.Interfaces;
using GeoCoordinatePortable;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Anuncios.Service.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnuncioController : Controller
    {
        private readonly IAppServiceAnuncio app;

        public class AnuncioDTOPost
        {
            public string Descricao { get; set; }
            public IFormFile ImageFile { get; set; }
            public bool IsAtivo { get; set; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }
        }

        public AnuncioController(IAppServiceAnuncio app)
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
            var anuncioDTO = app.GetById(id);
            if (anuncioDTO == null)
            {
                return NotFound("Anúncio não existe!");
            }
            anuncioDTO.ImagemBase64 = Convert.ToBase64String(anuncioDTO.Imagem);
            anuncioDTO.Imagem = null;

            return Ok(Json(anuncioDTO));
        }

        [HttpGet]
        [Authorize]
        [Route("BuscarPorLocalizacao")]
        public ActionResult<IEnumerable<string>> Get(double latitude, double longitude)
        {
            var anunciosDTOAux = new List<AnuncioDTO>();
            var anunciosDTO = app.GetAll();
            foreach (var anuncio in anunciosDTO)
            {
                var locA = new GeoCoordinate(latitude, longitude);
                var locB = new GeoCoordinate(anuncio.Latitude, anuncio.Longitude);

                double distance = locA.GetDistanceTo(locB);

                if (distance <= 15)
                {
                    anuncio.CountExibicao++;
                    app.Update(anuncio);
                    anuncio.ImagemBase64 = Convert.ToBase64String(anuncio.Imagem);
                    anuncio.Imagem = null;
                    anunciosDTOAux.Add(anuncio);
                }

            }

            if (anunciosDTOAux.Count == 0)
            {
                return NotFound(new { message = "Não existe anúncio próximo a sua localização!" });
            }


            return Ok(Json(anunciosDTOAux));
        }

        [HttpPost]
        [Authorize]
        [Route("Cadastrar")]
        public ActionResult Post([FromForm] AnuncioDTOPost anuncioDTOPost)
        {
            try
            {
                if (anuncioDTOPost == null || String.IsNullOrEmpty(anuncioDTOPost.Descricao) || anuncioDTOPost.ImageFile.Length <= 0 || !anuncioDTOPost.ImageFile.ContentType.Contains("image"))
                {
                    return NotFound("Os dados do anúncio não foram preenchidos corretamente!");
                }

                var anuncioDTO = new AnuncioDTO
                {
                    Descricao = anuncioDTOPost.Descricao,
                    IsAtivo = anuncioDTOPost.IsAtivo,
                    Latitude = anuncioDTOPost.Latitude,
                    Longitude = anuncioDTOPost.Longitude
                };

                using (var ms = new MemoryStream())
                {
                    anuncioDTOPost.ImageFile.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    anuncioDTO.Imagem = fileBytes;
                }

                app.Add(anuncioDTO);
                return Ok("Anúncio inserido com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [Authorize]
        [Route("Atualizar")]
        public ActionResult Put([FromBody] AnuncioDTO anuncioDTO)
        {
            try
            {
                if (anuncioDTO == null)
                {
                    return NotFound();
                }

                app.Update(anuncioDTO);
                return Ok("Anúncio atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("Excluir")]
        public ActionResult Delete([FromBody] AnuncioDTO anuncioDTO)
        {
            try
            {
                if (anuncioDTO == null)
                {
                    return NotFound();
                }

                app.Update(anuncioDTO);
                return Ok("Anúncio removido com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}