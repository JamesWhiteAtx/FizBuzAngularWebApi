In order to use this dll with Ninject:

1. Install nuuGet package Ninject.Mvc3
2. Edit App_Start/NinjectWebCommon.cs

add
	using System.Web.Http;
	using NinjectWebApi;
	using [services namespace]


        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            
            RegisterServices(kernel);

            GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);

            return kernel;
        }

and

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IServiceInterface>().To<ImplementedServiceClass>();
        }        
