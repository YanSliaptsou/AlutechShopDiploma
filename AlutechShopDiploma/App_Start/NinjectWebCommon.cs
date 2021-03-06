[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(AlutechShopDiploma.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(AlutechShopDiploma.App_Start.NinjectWebCommon), "Stop")]

namespace AlutechShopDiploma.App_Start
{
    using System;
    using System.Web;
    using AlutechShopDiploma.Models.Abstract;
    using AlutechShopDiploma.Models.Concrete;
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
                kernel.Bind<ICategoryRepository>().To<EFCategoryRepository>();
                kernel.Bind<IGoodRepository>().To<EFGoodRepository>();
                kernel.Bind<IUserMessageRepository>().To<EFUserMessageRepository>();
                kernel.Bind<ICommentRepository>().To<EFCommentRepository>();
                kernel.Bind<IMarkRepository>().To<EFMarkRepository>();
                kernel.Bind<IOrderRepository>().To<EFOrderRepository>();
                kernel.Bind<IOrderItemRepository>().To<EFOrderItemRepository>();
                kernel.Bind<IShippingDetailRepository>().To<EFShippingDetailRepository>();
                kernel.Bind<IDiscountRepository>().To<EFDiscountRepository>();
                kernel.Bind<IImageContainerRepositiry>().To<EFImageContainerRepositiry>();
                kernel.Bind<IWarehouseRepository>().To<EFWarehouseRepository>();
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
        }        
    }
}
