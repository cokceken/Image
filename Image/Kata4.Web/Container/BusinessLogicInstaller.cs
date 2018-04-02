using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Kata4.Core.Contract.Infrastructure.LogContract;
using Kata4.Core.Service;
using Kata4.Infrastructure.Log;

namespace Kata4.Web.Container
{
    public class BusinessLogicInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            InstallDomain(container, store);
            InstallInfrastructure(container, store);
        }

        public void InstallDomain(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssembly(Assembly.GetAssembly(typeof(ImageService)))
                .InSameNamespaceAs<ImageService>()
                .WithService.DefaultInterfaces()
                .LifestylePerWebRequest());
        }

        public void InstallInfrastructure(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ILogger>().ImplementedBy<Logger>().LifeStyle.Singleton);
        }
    }
}