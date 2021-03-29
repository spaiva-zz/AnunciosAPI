using Anuncios.Domain.Entities;
using Anuncios.Domain.Intefaces.Repositories;
using Anuncios.Domain.Intefaces.Services;

namespace Anuncios.Domain.Services
{
    public class ServiceCliente : ServiceBase<Cliente>, IServiceCliente

    {
        private readonly IRepositoryCliente repositoryCliente;

        public ServiceCliente(IRepositoryCliente repositoryCliente)
            : base(repositoryCliente)
        {
            this.repositoryCliente = repositoryCliente;
        }
    }
}