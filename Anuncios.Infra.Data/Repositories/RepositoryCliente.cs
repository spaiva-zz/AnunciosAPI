using Anuncios.Domain.Entities;
using Anuncios.Domain.Intefaces.Repositories;
using System.Linq;

namespace Anuncios.Infra.Data.Repositories
{
    public class RepositoryCliente : RepositoryBase<Cliente>, IRepositoryCliente
    {
        private readonly SqlContext sqlContext;

        public RepositoryCliente(SqlContext sqlContext)
            : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }
    }
}