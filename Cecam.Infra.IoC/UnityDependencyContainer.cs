using Cecam.Domain.Interfaces.Repository;
using Cecam.Domain.Interfaces.Repository.Base;
using Cecam.Domain.Interfaces.Service;
using Cecam.Domain.Interfaces.Service.Base;
using Cecam.Infra.Data.Repository;
using Cecam.Infra.Data.Repository.Base;
using Cecam.Service.Services;
using Cecam.Service.Services.Base;
using Unity;

namespace Cecam.Infra.IoC
{
    public static class UnityDependencyContainer
    {
        public static void RegisterDependencies(IUnityContainer container)
        {
            container.RegisterType(typeof(IRepositoryBase<>), (typeof(RepositoryBase<>)));
            container.RegisterType<ICompanyRepository, CompanyRepository>();

            //Serviços
            container.RegisterType(typeof(IServiceBase<>), (typeof(ServiceBase<>)));
            container.RegisterType<ICompanyService, CompanyService>();
        }
    }
}
