using Anuncios.Application.DTO;
using Anuncios.Application.Interfaces;
using Anuncios.Domain.Entities;
using Anuncios.Domain.Intefaces.Services;
using AutoMapper;
using System.Collections.Generic;

namespace Anuncios.Application.Services
{
    public class AppServiceBase<TEntity, TEntityDTO> : IAppServiceBase<TEntity, TEntityDTO> where TEntity : Base where TEntityDTO : BaseDTO
    {
        private readonly IMapper iMapper;
        private readonly IServiceBase<TEntity> service;

        public AppServiceBase(IMapper iMapper, IServiceBase<TEntity> service) : base()
        {
            this.iMapper = iMapper;
            this.service = service;
        }

        public void Add(TEntityDTO entity)
        {
            service.Add(iMapper.Map<TEntity>(entity));
        }

        public IEnumerable<TEntityDTO> GetAll()
        {
            return iMapper.Map<IEnumerable<TEntityDTO>>(service.GetAll());
        }

        public TEntityDTO GetById(int id)
        {
            return iMapper.Map<TEntityDTO>(service.GetById(id));
        }

        public void Remove(TEntityDTO entity)
        {
            service.Remove(iMapper.Map<TEntity>(entity));
        }

        public void Update(TEntityDTO entity)
        {
            service.Update(iMapper.Map<TEntity>(entity));
        }
    }
}