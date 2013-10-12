using Proto.Domain;

[assembly: WebActivator.PostApplicationStartMethod(typeof(Proto.Mvc.Mgmt.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace Proto.Mvc.Mgmt.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;

    using SimpleInjector;
    using SimpleInjector.Integration.Web.Mvc;
    
    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            // Did you know the container can diagnose your configuration? Go to: http://bit.ly/YE8OJj.
            var container = new Container();
            
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            container.RegisterMvcAttributeFilterProvider();
       
            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {
//#error Register your services here (remove this line).
            BusinessLayerBootstrapper.Bootstrap(container);

            // For instance:
            // container.Register<IUserRepository, SqlUserRepository>();
        }
    }
}