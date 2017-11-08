using System.Configuration;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(AppraisalTool.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(AppraisalTool.App_Start.NinjectWebCommon), "Stop")]

namespace AppraisalTool.App_Start
{
    using System;
    using System.Web;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Mvc.FilterBindingSyntax;
    using Ninject.Web.Common.WebHost;
    using Appraisal.Data;
    using Appraisal.Services;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper _bootStrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            _bootStrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            _bootStrapper.ShutDown();
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
            kernel.Bind<EFDbContext>()
                .ToSelf()
                .InRequestScope()
                .WithConstructorArgument("nameOrConnectionString",
                    ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            kernel.Bind<IValuesService>().To<ValuesService>().InRequestScope();
        }
    }
}