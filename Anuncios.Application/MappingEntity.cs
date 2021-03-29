using Anuncios.Application.DTO;
using Anuncios.Domain.Entities;
using AutoMapper;

namespace Anuncios.Application
{
    public class MappingEntity : Profile
    {
        public MappingEntity()
        {
            CreateMap<Cliente, ClienteDTO>();
            CreateMap<Anuncio, AnuncioDTO>();
            CreateMap<ClienteDTO, Cliente>();
            CreateMap<AnuncioDTO, Anuncio>();
        }
    }
}