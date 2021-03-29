using Anuncios.Domain.Entities;
using Anuncios.Domain.Intefaces.Repositories;
using Anuncios.Domain.Intefaces.Services;

namespace Anuncios.Domain.Services
{
    public class ServiceAnuncio : ServiceBase<Anuncio>, IServiceAnuncio
    {
        private readonly IRepositoryAnuncio repositoryAnuncio;

        public ServiceAnuncio(IRepositoryAnuncio repositoryAnuncio)
            : base(repositoryAnuncio)
        {
            this.repositoryAnuncio = repositoryAnuncio;
        }
    }
}