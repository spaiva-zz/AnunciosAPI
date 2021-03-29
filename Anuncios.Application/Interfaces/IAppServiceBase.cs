using Anuncios.Application.DTO;
using Anuncios.Domain.Entities;
using System.Collections.Generic;

namespace Anuncios.Application.Interfaces
{
    public interface IAppServiceBase<TEntity, TEntityDTO>
        where TEntity : Base
        where TEntityDTO : BaseDTO
    {
        void Add(TEntityDTO entity);

        void Remove(TEntityDTO entity);

        void Update(TEntityDTO entity);

        TEntityDTO GetById(int id);

        IEnumerable<TEntityDTO> GetAll();
    }
}