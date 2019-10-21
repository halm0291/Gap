using AppInfrastructure.Contracts;
using AppInfrastructure.DependencyInjection;
using AppServices;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace ClinicalTemplateApi.Infraestructure.DependencyInjection
{
    public class DependencyFactoryConfig
    {
        /// <summary>
        /// Register components using unity implementation
        /// </summary>
        public static IUnityContainer RegisterComponents()
        {
            IDependencyFactory dependencyFactory = new UnityDependencyFactory();

            var infrastructureServicesInjector = new AppServicesInjector();
            infrastructureServicesInjector.RegisterComponents(dependencyFactory);

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(dependencyFactory.Container<IUnityContainer>());
            dependencyFactory.RegisterInstance<IDependencyFactory>(dependencyFactory);
            return dependencyFactory.Container<IUnityContainer>();
        }
    }
}