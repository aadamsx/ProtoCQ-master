using System;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Proto.Data;
using Proto.Domain;
using Proto.WebApi.App_Start;
using SimpleInjector;
using SimpleInjector.Extensions;
using Proto.Domain.QueryHandlers;

namespace Proto.WebApi.CompositionRoot
{
    public static class Bootstrapper
    {
        private static Container container;

        public static object GetInstance(Type serviceType)
        {
            return container.GetInstance(serviceType);
        }

        public static T GetInstance<T>() where T : class
        {
            return container.GetInstance<T>();
        }

        public static void Bootstrap()
        {
            container = new Container();

            // Register your types
            DataLayerBootstrapper.Bootstrap(container);
            BusinessLayerBootstrapper.Bootstrap(container);

            var services = GlobalConfiguration.Configuration.Services;
            var controllerTypes = services.GetHttpControllerTypeResolver()
                .GetControllerTypes(services.GetAssembliesResolver());

            // register Web API controllers (important! http://bit.ly/1aMbBW0)
            foreach (var controllerType in controllerTypes)
            {
                container.Register(controllerType);
            }

            // Register types
            //RegisterWebApiSpecificDependencies();

            // Verify the container configuration
            container.Verify();

            // Register the dependency resolver.
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }

        //private static void RegisterDomainSpecificDependencies()
        //{
        //    container.RegisterManyForOpenGeneric(typeof(IQueryHandler<,>), Assembly.GetExecutingAssembly());
        //}

        //private static void RegisterWebApiSpecificDependencies(Container container)
        //{
        //    container.Register<IPrincipal>(() => HttpContext.Current.User ?? Thread.CurrentPrincipal);
        //    container.RegisterSingle<ILogger, DebugLogger>();
        //    container.RegisterSingle<IQueryProcessor, DynamicQueryProcessor>();

        //    // This provider builds the list of commands and queries.
        //    var provider = new CommandControllerDescriptorProvider(typeof(ICommandHandler<>).Assembly);

        //    container.RegisterSingle<CommandControllerDescriptorProvider>(provider);

        //    container.RegisterSingle<IHttpControllerSelector, CommandHttpControllerSelector>();
        //    container.RegisterSingle<IHttpActionSelector, CommandHttpActionSelector>();

        //    // This line is optional, but by registering all controllers explicitly, they will be
        //    // verified when calling Verify().
        //    foreach (var commandDescriptor in provider.GetDescriptors())
        //    {
        //        container.Register(commandDescriptor.ControllerDescriptor.ControllerType);
        //    }
        //}
    }
}