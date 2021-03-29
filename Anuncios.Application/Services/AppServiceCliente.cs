using Anuncios.Application.DTO;
using Anuncios.Application.Interfaces;
using Anuncios.Domain.Entities;
using Anuncios.Domain.Intefaces.Services;
using AutoMapper;

namespace Anuncios.Application.Services
{
    public class AppServiceCliente : AppServiceBase<Cliente, ClienteDTO>, IAppServiceCliente
    {
        public AppServiceCliente(IMapper iMapper, IServiceBase<Cliente> service) : base(iMapper, service)
        {
        }
    }
}