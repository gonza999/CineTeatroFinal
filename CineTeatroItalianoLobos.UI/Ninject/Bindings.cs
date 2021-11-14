using Ninject.Modules;
using CineTeatroItalianoLobos.Data;
using CineTeatroItalianoLobos.DataComun;
using CineTeatroItalianoLobos.DataComun.Facades;
using CineTeatroItalianoLobos.Services.Facades;
using CineTeatroItalianoLobos.Services;
using CineTeatroItalianoLobos.Data.Repositories;

namespace CineTeatroItalianoLobos.UI.Ninject
{
    public class Bindins : NinjectModule
    {
        public override void Load()
        {
            Bind<CineTeatroDbContext>().ToSelf().InSingletonScope();
            Bind<IUnitOfWork>().To<UnitOfWork>();

            Bind<IRepositorioTipoEventos>().To<TiposDeEventosRepositorio>();
            Bind<ITiposDeEventosServicios>().To<TiposDeEventosServicios>();

            Bind<IRepositorioClasificaciones>().To<ClasificacionesRepositorio>();
            Bind<IClasificacionesServicio>().To<ClasificacionesServicio>();

            Bind<IRepositorioUbicaciones>().To<UbicacionesRepositorio>();
            Bind<IUbicacionesServicio>().To<UbicacionesServicio>();

            Bind<IRepositorioFormasVentas>().To<FormasVentasRepositorio>();
            Bind<IFormasVentasServicio>().To<FormasVentasServicio>();

            Bind<IRepositorioFormasPagos>().To<FormasPagosRepositorio>();
            Bind<IFormasPagosServicio>().To<FormasPagosServicio>();

            Bind<IRepositorioPlantas>().To<PlantasRepositorio>();
            Bind<IPlantasServicio>().To<PlantasServicio>();

            Bind<IRepositorioTiposDocumentos>().To<TiposDocumentosRepositorio>();
            Bind<ITiposDocumentosServicio>().To<TiposDocumentosServicio>();

            Bind<IRepositorioEmpleados>().To<EmpleadosRepositorio>();
            Bind<IEmpleadosServicio>().To<EmpleadosServicio>();

            Bind<IRepositorioLocalidades>().To<LocalidadesRepositorio>();
            Bind<ILocalidadesServicio>().To<LocalidadesServicio>();

            Bind<IRepositorioDistribuciones>().To<DistribucionesRepositorio>();
            Bind<IDistribucionesServicio>().To<DistribucionesServicio>();

            Bind<IRepositorioDistribucionesLocalidades>().To<DistribucionesLocalidadesRepositorio>();

            Bind<IRepositorioEventos>().To<EventosRepositorio>();
            Bind<IEventosServicios>().To<EventosServicio>();

            Bind<IRepositorioHorarios>().To<HorariosRepositorio>();
            Bind<IHorariosServicio>().To<HorariosServicio>();

        }
    }
}
