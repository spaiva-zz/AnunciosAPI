using Anuncios.Application.DTO;
using Anuncios.Domain.Entities;

namespace Anuncios.Application.Interfaces
{
    public interface IAppServiceAnuncio : IAppServiceBase<Anuncio, AnuncioDTO>
    {
    }
}