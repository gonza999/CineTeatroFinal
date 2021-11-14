using CineTeatroItalianoLobos.Entities;
using CineTeatroItalianoLobos.Web.Models.Clasificacion;
using CineTeatroItalianoLobos.Web.Models.Distribucion;
using CineTeatroItalianoLobos.Web.Models.Evento;
using CineTeatroItalianoLobos.Web.Models.FormaPago;
using CineTeatroItalianoLobos.Web.Models.FormaVenta;
using CineTeatroItalianoLobos.Web.Models.Localidad;
using CineTeatroItalianoLobos.Web.Models.Planta;
using CineTeatroItalianoLobos.Web.Models.TipoEvento;
using CineTeatroItalianoLobos.Web.Models.Ubicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineTeatroItalianoLobos.Web.Clases
{
    public class Mapeador
    {
        #region TipoEventos
        public static List<TipoEventoListVm> ConstruirListaTipoEventoVm(List<TipoEvento> lista)
        {
            var listaVm = new List<TipoEventoListVm>();
            foreach (var te in lista)
            {
                var tipoEventoListVm = ConstruirTipoEventoListVm(te);
                listaVm.Add(tipoEventoListVm);
            }
            return listaVm;
        }
        public static TipoEventoListVm ConstruirTipoEventoListVm(TipoEvento te)
        {
            return new TipoEventoListVm()
            {
                TipoEventoId = te.TipoEventoId,
                Descripcion=te.Descripcion
            };
        }
        public static TipoEvento ContruirTipoEvento(TipoEventoEditVm tipoEventoEditVm)
        {
            return new TipoEvento()
            {
                TipoEventoId = tipoEventoEditVm.TipoEventoId,
                Descripcion = tipoEventoEditVm.Descripcion
            };
        }
        public static TipoEventoEditVm ConstruirTipoEventoEditVm(TipoEvento tipoEvento)
        {
            return new TipoEventoEditVm()
            {
                TipoEventoId = tipoEvento.TipoEventoId,
                Descripcion = tipoEvento.Descripcion
            };
        }
        public static TipoEventoDetail ConstruirTipoEventoDetailsVm(TipoEvento tipoEvento)
        {
            return new TipoEventoDetail()
            {
                TipoEventoId = tipoEvento.TipoEventoId,
                Descripcion = tipoEvento.Descripcion
            };
        }
        #endregion
        #region Clasificaciones
        public static ClasificacionDetail ConstruirClasificacionDetailsVm(Clasificacion clasificacion)
        {
            return new ClasificacionDetail()
            {
                ClasificacionId = clasificacion.ClasificacionId,
                Descripcion = clasificacion.Descripcion
            }; 
        }
        public static Clasificacion ContruirClasificacion(ClasificacionEditVm clasificacionEditVm)
        {
            return new Clasificacion()
            {
                ClasificacionId = clasificacionEditVm.ClasificacionId,
                Descripcion = clasificacionEditVm.Descripcion
            };
        }
        public static List<ClasificacionListVm> ConstruirListaClasificacionVm(List<Clasificacion> lista)
        {
            var listaVm =new List<ClasificacionListVm>();
            foreach (var c in lista)
            {
                var clasificacionListVm = ConstruirClasificacionListVm(c);
                listaVm.Add(clasificacionListVm);
            }
            return listaVm;
        }

        public static ClasificacionListVm ConstruirClasificacionListVm(Clasificacion c)
        {
            return new ClasificacionListVm()
            {
                ClasificacionId = c.ClasificacionId,
                Descripcion=c.Descripcion
            };
        }
        public static ClasificacionEditVm ConstruirClasificacionEditVm(Clasificacion c)
        {
            return new ClasificacionEditVm()
            {
                ClasificacionId = c.ClasificacionId,
                Descripcion = c.Descripcion
            };
        }
        #endregion
        #region Ubicaciones
        public static List<UbicacionListVm> ConstruirListaUbicacionVm(List<Ubicacion> lista)
        {
            List<UbicacionListVm> listaVm = new List<UbicacionListVm>();
            foreach (var u in lista)
            {
                var ubicacionVm = ConstruirUbicacionListVm(u);
                listaVm.Add(ubicacionVm);
            }
            return listaVm;
        }
        public static UbicacionEditVm ConstruirUbicacionEditVm(Ubicacion u)
        {
            return new UbicacionEditVm()
            {
                UbicacionId = u.UbicacionId,
                Descripcion = u.Descripcion
            };
        }
        public static Ubicacion ConstruirUbicacion(UbicacionEditVm ubicacionEditVm)
        {
            return new Ubicacion()
            {
                UbicacionId = ubicacionEditVm.UbicacionId,
                Descripcion = ubicacionEditVm.Descripcion
            };
        }
        public static UbicacionDetail ConstruirUbicacionDetail(Ubicacion u)
        {
            return new UbicacionDetail()
            {
                UbicacionId = u.UbicacionId,
                Descripcion = u.Descripcion
            };
        }
        public static UbicacionListVm ConstruirUbicacionListVm(Ubicacion u)
        {
            return new UbicacionListVm()
            {
                UbicacionId = u.UbicacionId,
                Descripcion=u.Descripcion
            };
        }
        #endregion
        #region Planta
        public static List<PlantaListVm> ConstruirListaPlantaVm(List<Planta> lista)
        {
            List<PlantaListVm> listaVm = new List<PlantaListVm>();
            foreach (var u in lista)
            {
                var plantaVm = ConstruirPlantaListVm(u);
                listaVm.Add(plantaVm);
            }
            return listaVm;
        }
        public static PlantaEditVm ConstruirPlantaEditVm(Planta u)
        {
            return new PlantaEditVm()
            {
                PlantaId = u.PlantaId,
                Descripcion = u.Descripcion
            };
        }
        public static Planta ConstruirPlanta(PlantaEditVm plantaEditVm)
        {
            return new Planta()
            {
                PlantaId = plantaEditVm.PlantaId,
                Descripcion = plantaEditVm.Descripcion
            };
        }
        public static PlantaDetail ConstruirPlantaDetail(Planta u)
        {
            return new PlantaDetail()
            {
                PlantaId = u.PlantaId,
                Descripcion = u.Descripcion
            };
        }
        public static PlantaListVm ConstruirPlantaListVm(Planta u)
        {
            return new PlantaListVm()
            {
                PlantaId = u.PlantaId,
                Descripcion = u.Descripcion
            };
        }
        #endregion
        #region FormasVentas
        public static FormaVentaDetail ConstruirFormaVentaDetailsVm(FormaVenta formaVenta)
        {
            return new FormaVentaDetail()
            {
                FormaVentaId = formaVenta.FormaVentaId,
                Descripcion = formaVenta.Descripcion
            };
        }
        public static FormaVenta ContruirFormaVenta(FormaVentaEditVm formaVentaEditVm)
        {
            return new FormaVenta()
            {
                FormaVentaId = formaVentaEditVm.FormaVentaId,
                Descripcion = formaVentaEditVm.Descripcion
            };
        }
        public static List<FormaVentaListVm> ConstruirListaFormaVentaVm(List<FormaVenta> lista)
        {
            var listaVm = new List<FormaVentaListVm>();
            foreach (var c in lista)
            {
                var formaVentaListVm = ConstruirFormaVentaListVm(c);
                listaVm.Add(formaVentaListVm);
            }
            return listaVm;
        }

        public static FormaVentaListVm ConstruirFormaVentaListVm(FormaVenta c)
        {
            return new FormaVentaListVm()
            {
                FormaVentaId = c.FormaVentaId,
                Descripcion = c.Descripcion
            };
        }
        public static FormaVentaEditVm ConstruirFormaVentaEditVm(FormaVenta c)
        {
            return new FormaVentaEditVm()
            {
                FormaVentaId = c.FormaVentaId,
                Descripcion = c.Descripcion
            };
        }
        #endregion
        #region FormasPagos
        public static FormaPagoDetail ConstruirFormaPagoDetailsVm(FormaPago formaPago)
        {
            return new FormaPagoDetail()
            {
                FormaPagoId = formaPago.FormaPagoId,
                Descripcion = formaPago.Descripcion
            };
        }
        public static FormaPago ContruirFormaPago(FormaPagoEditVm formaPagoEditVm)
        {
            return new FormaPago()
            {
                FormaPagoId = formaPagoEditVm.FormaPagoId,
                Descripcion = formaPagoEditVm.Descripcion
            };
        }
        public static List<FormaPagoListVm> ConstruirListaFormaPagoVm(List<FormaPago> lista)
        {
            var listaVm = new List<FormaPagoListVm>();
            foreach (var c in lista)
            {
                var formaPagoListVm = ConstruirFormaPagoListVm(c);
                listaVm.Add(formaPagoListVm);
            }
            return listaVm;
        }

        public static FormaPagoListVm ConstruirFormaPagoListVm(FormaPago c)
        {
            return new FormaPagoListVm()
            {
                FormaPagoId = c.FormaPagoId,
                Descripcion = c.Descripcion
            };
        }
        public static FormaPagoEditVm ConstruirFormaPagoEditVm(FormaPago c)
        {
            return new FormaPagoEditVm()
            {
                FormaPagoId = c.FormaPagoId,
                Descripcion = c.Descripcion
            };
        }
        #endregion
        #region Eventos
        public static List<EventoListVm> ConstruirListaEventosVm(List<Evento> lista)
        {
            var listaVm = new List<EventoListVm>();
            foreach (var e in lista)
            {
                var eventoListVm = ConstruirEventoListVm(e);
                listaVm.Add(eventoListVm);
            }
            return listaVm;
        }

        public static EventoListVm ConstruirEventoListVm(Evento e)
        {
            return new EventoListVm()
            {
                EventoId = e.EventoId,
                NombreEvento=e.NombreEvento,
                Descripcion=e.Descripcion,
                Suspendido=e.Suspendido,
                TipoEvento=e.TipoEvento.Descripcion,
                Clasificacion=e.Clasificacion.Descripcion,
                Distribucion=e.Distribucion.Descripcion
            };
        }
        #endregion
        #region Localidades
        public static List<LocalidadListVm> ConstruirListaLocalidadesVm(List<Localidad> lista)
        {
            var listaVm = new List<LocalidadListVm>();
            foreach (var l in lista)
            {
                var localidadListVm = ConstruirLocalidadListVm(l);
                listaVm.Add(localidadListVm);
            }
            return listaVm;
        }

        public static LocalidadListVm ConstruirLocalidadListVm(Localidad l)
        {
            return new LocalidadListVm()
            {
                LocalidadId = l.LocalidadId,
                Fila=l.Fila,
                Numero=l.Numero,
                Planta=l.Planta.Descripcion,
                Ubicacion=l.Ubicacion.Descripcion
            };
        }
        #endregion
        #region Distribuciones
        public static DistribucionDetail ConstruirDistribucionDetailsVm(Distribucion distribucion)
        {
            return new DistribucionDetail()
            {
                DistribucionId = distribucion.DistribucionId,
                Descripcion = distribucion.Descripcion
            };
        }
        public static Distribucion ContruirDistribucion(DistribucionEditVm distribucionEditVm)
        {
            return new Distribucion()
            {
                DistribucionId = distribucionEditVm.DistribucionId,
                Descripcion = distribucionEditVm.Descripcion
            };
        }
        public static List<DistribucionListVm> ConstruirListaDistribucionVm(List<Distribucion> lista)
        {
            var listaVm = new List<DistribucionListVm>();
            foreach (var c in lista)
            {
                var distribucionListVm = ConstruirDistribucionListVm(c);
                listaVm.Add(distribucionListVm);
            }
            return listaVm;
        }

        public static DistribucionListVm ConstruirDistribucionListVm(Distribucion c)
        {
            return new DistribucionListVm()
            {
                DistribucionId = c.DistribucionId,
                Descripcion = c.Descripcion
            };
        }
        public static DistribucionEditVm ConstruirDistribucionEditVm(Distribucion c)
        {
            return new DistribucionEditVm()
            {
                DistribucionId = c.DistribucionId,
                Descripcion = c.Descripcion
            };
        }
        #endregion
    }
}