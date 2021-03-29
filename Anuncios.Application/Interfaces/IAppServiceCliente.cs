using Anuncios.Application.DTO;
using Anuncios.Domain.Entities;

namespace Anuncios.Application.Interfaces
{
    public interface IAppServiceCliente : IAppServiceBase<Cliente, ClienteDTO>
    {
    }
}