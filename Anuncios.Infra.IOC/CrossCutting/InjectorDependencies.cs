using Anuncios.Application.Interfaces;
using Anuncios.Application.Services;
using Anuncios.Domain.Intefaces.Repositories;
using Anuncios.Domain.Intefaces.Services;
using Anuncios.Domain.Services;
using Anuncios.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anuncios.Infra.IOC.CrossCutting
{
    public class InjectorDependencies
    {
        public static void Register(IServiceCollection svcCollection)
        {
            svcCollection.AddScoped(typeof(IAppServiceBase<,>), typeof(AppServiceBase<,>));
            svcCollection.AddScoped<IAppServiceAnuncio, AppServiceAnuncio>();
            svcCollection.AddScoped<IAppServiceCliente, AppServiceCliente>();

            svcCollection.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            svcCollection.AddScoped<IServiceAnuncio, ServiceAnuncio>();
            svcCollection.AddScoped<IServiceCliente, ServiceCliente>();

            svcCollection.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            svcCollection.AddScoped<IRepositoryAnuncio, RepositoryAnuncio>();
            svcCollection.AddScoped<IRepositoryCliente, RepositoryCliente>();
        }
    }
}
