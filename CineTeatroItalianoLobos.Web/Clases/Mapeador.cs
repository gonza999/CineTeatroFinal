using CineTeatroItalianoLobos.Entities;
using CineTeatroItalianoLobos.Web.Models.Clasificacion;
using CineTeatroItalianoLobos.Web.Models.Distribucion;
using CineTeatroItalianoLobos.Web.Models.Empleado;
using CineTeatroItalianoLobos.Web.Models.Evento;
using CineTeatroItalianoLobos.Web.Models.FormaPago;
using CineTeatroItalianoLobos.Web.Models.FormaVenta;
using CineTeatroItalianoLobos.Web.Models.Horario;
using CineTeatroItalianoLobos.Web.Models.Localidad;
using CineTeatroItalianoLobos.Web.Models.Planta;
using CineTeatroItalianoLobos.Web.Models.Ticket;
using CineTeatroItalianoLobos.Web.Models.TipoDocumento;
using CineTeatroItalianoLobos.Web.Models.TipoEvento;
using CineTeatroItalianoLobos.Web.Models.Ubicacion;
using CineTeatroItalianoLobos.Web.Models.Venta;
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
                Descripcion = te.Descripcion
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
            var listaVm = new List<ClasificacionListVm>();
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
                Descripcion = c.Descripcion
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
                Descripcion = u.Descripcion
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
        #region TiposDocumentos
        public static List<TipoDocumentoListVm> ConstruirListaTipoDocumentoVm(List<TipoDocumento> lista)
        {
            var listaVm = new List<TipoDocumentoListVm>();
            foreach (var te in lista)
            {
                var tipoDocumentoListVm = ConstruirTipoDocumentoListVm(te);
                listaVm.Add(tipoDocumentoListVm);
            }
            return listaVm;
        }
        public static TipoDocumento ConstruirTipoDocumento(TipoDocumentoListVm te)
        {
            return new TipoDocumento()
            {
                TipoDocumentoId = te.TipoDocumentoId,
                Descripcion = te.Descripcion
            };
        }

        public static TipoDocumentoListVm ConstruirTipoDocumentoListVm(TipoDocumento te)
        {
            return new TipoDocumentoListVm()
            {
                TipoDocumentoId = te.TipoDocumentoId,
                Descripcion = te.Descripcion
            };
        }
        public static TipoDocumento ContruirTipoDocumento(TipoDocumentoEditVm tipoDocumentoEditVm)
        {
            return new TipoDocumento()
            {
                TipoDocumentoId = tipoDocumentoEditVm.TipoDocumentoId,
                Descripcion = tipoDocumentoEditVm.Descripcion
            };
        }
        public static TipoDocumentoEditVm ConstruirTipoDocumentoEditVm(TipoDocumento tipoDocumento)
        {
            return new TipoDocumentoEditVm()
            {
                TipoDocumentoId = tipoDocumento.TipoDocumentoId,
                Descripcion = tipoDocumento.Descripcion
            };
        }
        public static TipoDocumentoDetail ConstruirTipoDocumentoDetailsVm(TipoDocumento tipoDocumento)
        {
            return new TipoDocumentoDetail()
            {
                TipoDocumentoId = tipoDocumento.TipoDocumentoId,
                Descripcion = tipoDocumento.Descripcion
            };
        }
        #endregion
        #region Empleados 
        public static List<EmpleadoListVm> ConstruirListaEmpleadosVm(List<Empleado> lista)
        {
            var listaVm = new List<EmpleadoListVm>();
            foreach (var e in lista)
            {
                var empleadoListVm = ConstruirEmpleadoListVm(e);
                listaVm.Add(empleadoListVm);
            }
            return listaVm;
        }

        public static EmpleadoListVm ConstruirEmpleadoListVm(Empleado e)
        {
            return new EmpleadoListVm()
            {
                EmpleadoId = e.EmpleadoId,
                Nombre = e.Nombre,
                Apellido = e.Apellido,
                NroDocumento = e.NroDocumento,
                TipoDocumento = e.TipoDocumento.Descripcion,
                //Mail = e.Mail,
                //TelefonoFijo = e.TelefonoFijo,
                //TelefonoMovil = e.TelefonoMovil
            };
        }
        public static Empleado ConstruirEmpleado(EmpleadoEditVm e)
        {
            return new Empleado()
            {
                EmpleadoId = e.EmpleadoId,
                Nombre = e.Nombre,
                Apellido = e.Apellido,
                NroDocumento = e.NroDocumento,
                TipoDocumentoId = e.TipoDocumentoId,
                Mail = e.Mail,
                TelefonoFijo = e.TelefonoFijo,
                TelefonoMovil = e.TelefonoMovil
            };
        }
        public static EmpleadoDetail ConstruirEmpleadoDetailsVm(Empleado e)
        {
            return new EmpleadoDetail()
            {
                EmpleadoId = e.EmpleadoId,
                Nombre = e.Nombre,
                Apellido = e.Apellido,
                NroDocumento = e.NroDocumento,
                TipoDocumento = e.TipoDocumento.Descripcion,
                Mail = e.Mail,
                TelefonoFijo = e.TelefonoFijo,
                TelefonoMovil = e.TelefonoMovil
            };
        }
        public static Empleado ContruirEmpleado(EmpleadoEditVm e)
        {
            return new Empleado()
            {
                EmpleadoId = e.EmpleadoId,
                Nombre = e.Nombre,
                Apellido = e.Apellido,
                NroDocumento = e.NroDocumento,
                TipoDocumentoId = e.TipoDocumentoId,
                Mail = e.Mail,
                TelefonoFijo = e.TelefonoFijo,
                TelefonoMovil = e.TelefonoMovil
            };
        }
        public static EmpleadoEditVm ConstruirEmpleadoEditVm(Empleado e)
        {
            return new EmpleadoEditVm()
            {
                EmpleadoId = e.EmpleadoId,
                Nombre = e.Nombre,
                Apellido = e.Apellido,
                NroDocumento = e.NroDocumento,
                TipoDocumentoId = e.TipoDocumentoId,
                Mail = e.Mail,
                TelefonoFijo = e.TelefonoFijo,
                TelefonoMovil = e.TelefonoMovil
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
                NombreEvento = e.NombreEvento,
                Suspendido = e.Suspendido,
                TipoEvento = e.TipoEvento.Descripcion,
                Clasificacion = e.Clasificacion.Descripcion,
                Distribucion = e.Distribucion.Descripcion,
                CantidadHorarios=e.Horarios.Count
            };
        }
        public static Evento ConstruirEvento(EventoEditVm e)
        {
            return new Evento()
            {
                EventoId = e.EventoId,
                NombreEvento = e.NombreEvento,
                Suspendido = e.Suspendido,
                TipoEventoId = e.TipoEventoId,
                ClasificacionId = e.ClasificacionId,
                DistribucionId = e.DistribucionId,
                Descripcion=e.Descripcion,
                FechaEvento=e.FechaEvento
                
            };
        }
        public static EventoDetail ConstruirEventoDetailsVm(Evento e, List<Horario> horarios)
        {
            return new EventoDetail()
            {
                EventoId = e.EventoId,
                NombreEvento = e.NombreEvento,
                Suspendido = e.Suspendido,
                TipoEvento = e.TipoEvento.Descripcion,
                Clasificacion= e.Clasificacion.Descripcion,
                Distribucion = e.Distribucion.Descripcion,
                Descripcion = e.Descripcion,
                FechaEvento = e.FechaEvento.Year+"/"+e.FechaEvento.Month+"/"+
                e.FechaEvento.Day,
                CantidadHorarios=horarios.Count(),
                Horarios=Mapeador.ConstruirListaHorarioVm(horarios)
            };
        }



        public static EventoEditVm ConstruirEventoEditVm(Evento e)
        {
            return new EventoEditVm()
            {
                EventoId = e.EventoId,
                NombreEvento = e.NombreEvento,
                Suspendido = e.Suspendido,
                TipoEventoId = e.TipoEventoId,
                ClasificacionId = e.ClasificacionId,
                DistribucionId = e.DistribucionId,
                Descripcion = e.Descripcion,
                FechaEvento = e.FechaEvento
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
                Fila = l.Fila,
                Numero = l.Numero,
                Planta = l.Planta.Descripcion,
                Ubicacion = l.Ubicacion.Descripcion
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
        #region Horarios
        public static List<HorarioListVm> ConstruirListaHorarioVm(ICollection<Horario> horarios)
        {
            var listaVm = new List<HorarioListVm>();
            foreach (var h in horarios)
            {
                var horarioListVm = ConstruirHorarioListVm(h);
                listaVm.Add(horarioListVm);
            }
            return listaVm;
        }

        public static HorarioListVm ConstruirHorarioListVm(Horario h)
        {
            return new HorarioListVm()
            {
                HorarioId = h.HorarioId,
                Evento = h.Evento.NombreEvento,
                Fecha = h.Fecha,
                Hora = h.Hora,
                FechaYHora = h.FechaYHora
            };
        }

        public static Horario ConstruirHorario(HorarioEditVm horarioEditVm)
        {
            return new Horario()
            {
                Hora = horarioEditVm.Hora,
                Fecha=horarioEditVm.Fecha,
                //Evento=ConstruirEvento(horarioEditVm.Evento),
                EventoId=horarioEditVm.EventoId,
                HorarioId=horarioEditVm.HorarioId
            };
        }
        #endregion
        #region Tickets
        public static List<TicketListVm> ConstruirListaTicketVm(List<Ticket> lista)
        {
            var listaVm = new List<TicketListVm>();
            foreach (var t in lista)
            {
                var ticketListVm = ConstruirTicketListVm(t);
                listaVm.Add(ticketListVm);
            }
            return listaVm;
        }

        public static TicketListVm ConstruirTicketListVm(Ticket t)
        {
            return new TicketListVm()
            {
                TicketId = t.TicketId,
                Evento=t.Horario.Evento.NombreEvento,
                FormaPago=t.FormaPago.Descripcion,
                FormaVenta=t.FormaVenta.Descripcion,
                Importe=t.Importe
            };
        }
        #endregion
        #region Ventas
        public static List<VentaListVm> ConstuirListaVentaVm(List<Venta> lista)
        {
            var listaVm = new List<VentaListVm>();
            foreach (var v in lista)
            {
                var ventaListVm = ConstruirVentaListVm(v);
                listaVm.Add(ventaListVm);
            }
            return listaVm;
        }

        private static VentaListVm ConstruirVentaListVm(Venta v)
        {
            return new VentaListVm()
            {
                VentaId=v.VentaId,
                Empleado=v.Empleado.Nombre,
                Estado=v.Estado,
                Fecha=v.Fecha,
                Total=v.Total,
                CantidadTickets=v.VentasTickets.Count()
            };
        }

        #endregion
    }
}