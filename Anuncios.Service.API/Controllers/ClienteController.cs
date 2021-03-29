using Anuncios.Application.DTO;
using Anuncios.Application.Interfaces;
using Anuncios.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Anuncios.Service.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClienteController : BaseController<Cliente, ClienteDTO>
    {
        public ClienteController(IAppServiceCliente app) : base(app)
        {
        }
    }
}