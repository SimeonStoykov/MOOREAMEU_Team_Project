using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Mooreameu.Data;
using Mooreameu.Data.UnitOfWork;
using Mooreameu.Model;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Mooreameu.App.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Mooreameu.App.App_Start.NinjectWebCommon), "Stop")]

namespace Mooreameu.App.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IMooreameuData>().To<MooreameuData>()
                .InRequestScope()
                .WithConstructorArgument("context", p => new MooreameuDbContext());
            kernel.Bind<IUserStore<User>>().To<UserStore<User>>()
                .InRequestScope()
                .WithConstructorArgument("context", kernel.Get<MooreameuDbContext>());
            kernel.Bind<IAuthenticationManager>()
                .ToMethod<IAuthenticationManager>(context => HttpContext.Current.GetOwinContext().Authentication).InRequestScope();
        }        
    }
}
