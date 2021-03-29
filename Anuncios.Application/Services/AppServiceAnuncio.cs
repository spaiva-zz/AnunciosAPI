using Anuncios.Application.DTO;
using Anuncios.Application.Interfaces;
using Anuncios.Domain.Entities;
using Anuncios.Domain.Intefaces.Services;
using AutoMapper;

namespace Anuncios.Application.Services
{
    public class AppServiceAnuncio : AppServiceBase<Anuncio, AnuncioDTO>, IAppServiceAnuncio
    {
        public AppServiceAnuncio(IMapper iMapper, IServiceBase<Anuncio> service) : base(iMapper, service)
        {
        }
    }
}