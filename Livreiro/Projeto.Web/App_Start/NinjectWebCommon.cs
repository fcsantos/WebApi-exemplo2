[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Projeto.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Projeto.Web.App_Start.NinjectWebCommon), "Stop")]

namespace Projeto.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Application.Contracts;
    using Application.Services;
    using Domain.Contracts.Services;
    using Domain.Services;
    using Domain.Contracts.Repository;
    using Infra.Persistence.Repository;
    using System.Web.Http;
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
                //linha de comando para ler as dependencias mapeadas
                //quando o projeto for executado
                GlobalConfiguration.Configuration.DependencyResolver = kernel.Get<System.Web.Http.Dependencies.IDependencyResolver>();

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
            //registrar as interfaces e classes do sistema

            //NIVEL DE APLICAÇÃO
            kernel.Bind(typeof(IApplicationServiceBase<>)).To(typeof(ApplicationServiceBase<>));
            kernel.Bind(typeof(IApplicationServiceAutor)).To(typeof(ApplicationServiceAutor));
            kernel.Bind(typeof(IApplicationServiceLivro)).To(typeof(ApplicationServiceLivro));
            kernel.Bind(typeof(IApplicationServiceEditora)).To(typeof(ApplicationServiceEditora));

            //NIVEL DE DOMÍNIO
            kernel.Bind(typeof(IDomainServiceBase<>)).To(typeof(DomainServiceBase<>));
            kernel.Bind(typeof(IDomainServiceAutor)).To(typeof(DomainServiceAutor));
            kernel.Bind(typeof(IDomainServiceLivro)).To(typeof(DomainServiceLivro));
            kernel.Bind(typeof(IDomainServiceEditora)).To(typeof(DomainServiceEditora));

            //NIVEL DE REPOSITORY
            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind(typeof(IRepositoryAutor)).To(typeof(RepositoryAutor));
            kernel.Bind(typeof(IRepositoryLivro)).To(typeof(RepositoryLivro));
            kernel.Bind(typeof(IRepositoryEditora)).To(typeof(RepositoryEditora));
        }        
    }
}
