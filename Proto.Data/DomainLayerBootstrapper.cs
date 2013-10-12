﻿using System;
using SimpleInjector;
using SimpleInjector.Extensions;

namespace Proto.Data
{
    // This class allows registering all types that are defined in the business layer, and are shared across
    // all applications that use this layer (WCF and Web API). For simplicity, this class is placed inside this
    // assembly, but this does couple the business layer assembly to the used container. If this is a concern,
    // create a specific BusinessLayer.Bootstrap project with this class.
    public static class DataLayerBootstrapper
    {
        public static void Bootstrap(Container container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            //container.RegisterSingle<IValidator>(new DataAnnotationsValidator(container));

            //container.RegisterManyForOpenGeneric(typeof(ICommandHandler<>), Assembly.GetExecutingAssembly());
            //container.RegisterDecorator(typeof(ICommandHandler<>), typeof(ValidationCommandHandlerDecorator<>));
            //container.RegisterDecorator(typeof(ICommandHandler<>), typeof(AuthorizationCommandHandlerDecorator<>));

            //container.RegisterManyForOpenGeneric(typeof(IQueryHandler<,>), Assembly.GetExecutingAssembly());
            //container.RegisterManyForOpenGeneric(typeof(IQueryHandler<,>), typeof(IQueryHandler<,>).Assembly);
            //container.RegisterDecorator(typeof(IQueryHandler<,>), typeof(AuthorizationQueryHandlerDecorator<,>));

            //container.RegisterManyForOpenGeneric(typeof(IQueryHandler<,>),
            //typeof(IQueryHandler<,>).Assembly);
        }
    }
}
