using System;
using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using CineTeatroItalianoLobos.Web;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]

namespace CineTeatroItalianoLobos.Web
{
    using System;
    using System.Web;
    using CineTeatroItalianoLobos.Data;
    using CineTeatroItalianoLobos.Data.Repositories;
    using CineTeatroItalianoLobos.DataComun;
    using CineTeatroItalianoLobos.DataComun.Facades;
    using CineTeatroItalianoLobos.Services;
    using CineTeatroItalianoLobos.Services.Facades;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application.
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
            kernel.Bind<IClasificacionesServicio>().To<ClasificacionesServicio>().InRequestScope();
            kernel.Bind<IRepositorioClasificaciones>().To<ClasificacionesRepositorio>().InRequestScope();
            kernel.Bind<IDistribucionesServicio>().To<DistribucionesServicio>().InRequestScope();
            kernel.Bind<IRepositorioDistribuciones>().To<DistribucionesRepositorio>().InRequestScope();
            kernel.Bind<IRepositorioDistribucionesLocalidades>().To<DistribucionesLocalidadesRepositorio>().InRequestScope();
            kernel.Bind<IEmpleadosServicio>().To<EmpleadosServicio>().InRequestScope();
            kernel.Bind<IRepositorioEmpleados>().To<EmpleadosRepositorio>().InRequestScope();
            kernel.Bind<IEventosServicios>().To<EventosServicio>().InRequestScope();
            kernel.Bind<IRepositorioEventos>().To<EventosRepositorio>().InRequestScope();
            kernel.Bind<IFormasPagosServicio>().To<FormasPagosServicio>().InRequestScope();
            kernel.Bind<IRepositorioFormasPagos>().To<FormasPagosRepositorio>().InRequestScope();
            kernel.Bind<IFormasVentasServicio>().To<FormasVentasServicio>().InRequestScope();
            kernel.Bind<IRepositorioFormasVentas>().To<FormasVentasRepositorio>().InRequestScope();
            kernel.Bind<IHorariosServicio>().To<HorariosServicio>().InRequestScope();
            kernel.Bind<IRepositorioHorarios>().To<HorariosRepositorio>().InRequestScope(); 
            kernel.Bind<ILocalidadesServicio>().To<LocalidadesServicio>().InRequestScope();
            kernel.Bind<IRepositorioLocalidades>().To<LocalidadesRepositorio>().InRequestScope(); 
            kernel.Bind<IPlantasServicio>().To<PlantasServicio>().InRequestScope(); 
            kernel.Bind<IRepositorioPlantas>().To<PlantasRepositorio>().InRequestScope(); 
            kernel.Bind<ITiposDeEventosServicios>().To<TiposDeEventosServicios>().InRequestScope();
            kernel.Bind<IRepositorioTipoEventos>().To<TiposDeEventosRepositorio>().InRequestScope();
            kernel.Bind<ITiposDocumentosServicio>().To<TiposDocumentosServicio>().InRequestScope();
            kernel.Bind<IRepositorioTiposDocumentos>().To<TiposDocumentosRepositorio>().InRequestScope();
            kernel.Bind<IUbicacionesServicio>().To<UbicacionesServicio>().InRequestScope();
            kernel.Bind<IRepositorioUbicaciones>().To<UbicacionesRepositorio>().InRequestScope();
            kernel.Bind<IRepositorioVentas>().To<VentasRepositorio>().InRequestScope();
            kernel.Bind<IVentasServicio>().To<VentasServicio>().InRequestScope();
            kernel.Bind<IRepositorioTickets>().To<TicketsRepositorio>().InRequestScope();
            kernel.Bind<ITicketsServicio>().To<TicketsServicio>().InRequestScope();
            kernel.Bind<IRepositorioVentasTickets>().To<VentasTicketsRepositorio>().InRequestScope();

            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind(typeof(CineTeatroDbContext)).ToSelf().InSingletonScope();
        }
    }
}