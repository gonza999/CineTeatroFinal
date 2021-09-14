using Ninject.Modules;
using CineTeatroItalianoLobos.Data;
using CineTeatroItalianoLobos.DataComun;
using CineTeatroItalianoLobos.DataComun.Facades;

namespace CineTeatroItalianoLobos.UI.Ninject
{
    public class Bindins : NinjectModule
    {
        public override void Load()
        {
            Bind<CineTeatroDbContext>().ToSelf().InSingletonScope();
            Bind<IUnitOfWork>().To<UnitOfWork>();

            Bind<IRepositorioClasificaciones>().To<PaisesRepositorio>();
            Bind<IPaisesServicios>().To<PaisesServicios>();

            Bind<IRepositorioDistribuciones>().To<CategoriasRepositorio>();
            Bind<ICategoriasServicios>().To<CategoriasServicios>();

            Bind<IRepositorioDistribucionesLocalidades>().To<CiudadesRepositorio>();
            Bind<ICiudadesServicios>().To<CiudadesServicios>();

            Bind<IRepositorioEmpleados>().To<ClientesRepositorio>();
            Bind<IClientesServicios>().To<ClientesServicios>();

            Bind<IRepositorioEventos>().To<ProveedoresRepositorio>();
            Bind<IProveedoresServicios>().To<ProveedoresServicios>();

            Bind<IRepositorioFormasPagos>().To<ProductosRepositorio>();
            Bind<IProductosServicios>().To<ProductosServicios>();

            Bind<IRepositorioFormasVentas>().To<OrdenesRepositorio>();
            Bind<IOrdenesServicios>().To<OrdenesServicios>();

            Bind<IRepositorioHorarios>().To<PaisesReportes>();
            Bind<ICategoriasReportes>().To<CategoriasReportes>();

            Bind<IRepositorioLocalidades>().To<PaisesReportes>();
            Bind<ICategoriasReportes>().To<CategoriasReportes>();

            Bind<IRepositorioPlantas>().To<PaisesReportes>();
            Bind<ICategoriasReportes>().To<CategoriasReportes>();

            Bind<IRepositorioTickets>().To<PaisesReportes>();
            Bind<ICategoriasReportes>().To<CategoriasReportes>();
            
            Bind<IRepositorioTipoEventos>().To<PaisesReportes>();
            Bind<ICategoriasReportes>().To<CategoriasReportes>();

            Bind<IRepositorioTiposDocumentos>().To<PaisesReportes>();
            Bind<ICategoriasReportes>().To<CategoriasReportes>();

            Bind<IRepositorioUbicaciones>().To<PaisesReportes>();
            Bind<ICategoriasReportes>().To<CategoriasReportes>();
           
            Bind<IRepositorioVentas>().To<PaisesReportes>();
            Bind<ICategoriasReportes>().To<CategoriasReportes>();

            Bind<IRepositorioVentasTickets>().To<PaisesReportes>();
            Bind<ICategoriasReportes>().To<CategoriasReportes>();

            //Bind<IManejadorDeReportes>().To<ManejadorDeReportes>();

        }
    }
}
