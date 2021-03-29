using Anuncios.Domain.Entities;
using Anuncios.Domain.Intefaces.Repositories;

namespace Anuncios.Infra.Data.Repositories
{
    public class RepositoryAnuncio : RepositoryBase<Anuncio>, IRepositoryAnuncio
    {
        private readonly SqlContext sqlContext;

        public RepositoryAnuncio(SqlContext sqlContext) : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }
    }
}