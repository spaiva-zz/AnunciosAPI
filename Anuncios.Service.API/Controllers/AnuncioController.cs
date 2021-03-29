using Anuncios.Application.DTO;
using Anuncios.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Anuncios.Service.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnuncioController : BaseController<Anuncios.Domain.Entities.Anuncio, AnuncioDTO>
    {
        public AnuncioController(IAppServiceAnuncio app) : base(app)
        {
        }
    }
}