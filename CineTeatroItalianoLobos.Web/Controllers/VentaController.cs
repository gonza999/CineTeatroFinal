using CineTeatroItalianoLobos.Entities;
using CineTeatroItalianoLobos.Services.Facades;
using CineTeatroItalianoLobos.Web.Clases;
using CineTeatroItalianoLobos.Web.Models.Carrito;
using CineTeatroItalianoLobos.Web.Models.Evento;
using CineTeatroItalianoLobos.Web.Models.Horario;
using CineTeatroItalianoLobos.Web.Models.Localidad;
using CineTeatroItalianoLobos.Web.Models.Ticket;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CineTeatroItalianoLobos.Web.Controllers
{
    public class VentaController : Controller
    {
        private readonly IVentasServicio _servicio;
        private readonly IEmpleadosServicio _servicioEmpleados;
        private readonly IEventosServicios _servicioEventos;
        private readonly ITicketsServicio _servicioTickets;
        private readonly IHorariosServicio _servicioHorarios;
        private readonly ILocalidadesServicio _servicioLocalidades;
        private readonly int cantidadPorPaginas = 12;
        public VentaController(IVentasServicio servicio,
            IEmpleadosServicio servicioEmpleados,
            ITicketsServicio servicioTickets, IEventosServicios servicioEventos,
            IHorariosServicio servicioHorarios, ILocalidadesServicio servicioLocalidades
            )
        {
            _servicio = servicio;
            _servicioEmpleados = servicioEmpleados;
            _servicioTickets = servicioTickets;
            _servicioEventos = servicioEventos;
            _servicioHorarios = servicioHorarios;
            _servicioLocalidades = servicioLocalidades;
        }
        public ActionResult Index(int? empleadoSeleccionadoId = null, int? page = null)
        {
            page = (page ?? 1);
            if (empleadoSeleccionadoId != null)
            {
                Session["empleadoSeleccionadoId"] = empleadoSeleccionadoId;
            }
            else
            {
                if (Session["empleadoSeleccionadoId"] != null)
                {
                    empleadoSeleccionadoId = (int)Session["empleadoSeleccionadoId"];
                }
            }
            List<Venta> lista;
            if (empleadoSeleccionadoId != null)
            {
                if (empleadoSeleccionadoId.Value > 0)
                {
                    var e = _servicioEmpleados.GetTEntityPorId(empleadoSeleccionadoId.Value);
                    lista = _servicio.GetLista(e);
                }
                else
                {
                    lista = _servicio.GetLista();
                }
            }
            else
            {
                lista = _servicio.GetLista();
            }
            var listaVm = Mapeador.ConstuirListaVentaVm(lista);
            var listaEmpleados = _servicioEmpleados.GetLista();
            listaEmpleados.Insert(0, new Empleado() { EmpleadoId = 0, Nombre = "[Seleccione un Empleado]" });
            listaEmpleados.Insert(1, new Empleado() { EmpleadoId = -1, Nombre = "[Ver Todos]" });

            ViewBag.Empleados = new SelectList(listaEmpleados, "EmpleadoId", "Nombre", empleadoSeleccionadoId);


            return View(listaVm.ToPagedList((int)page, cantidadPorPaginas));
        }
        [HttpGet]
        public ActionResult ChoiseEvent()
        {
            var carrito = new Carrito();
            carrito.Eventos = ConstruirListaEventosSinSuspender();
            carrito.Horarios = new List<HorarioListVm>();
            carrito.Localidades = new List<LocalidadListVm>();
            carrito.EventoId = -1;
            carrito.HorarioId = -1;
            return View(carrito);
        }

        private List<EventoListVm> ConstruirListaEventosSinSuspender()
        {
            List<Evento> lista = _servicioEventos.GetLista();
            var listaSuspendidos = new List<Evento>();
            foreach (var e in lista)
            {
                if (e.Suspendido)
                {
                    listaSuspendidos.Add(e);
                }

            }
            foreach (var e in listaSuspendidos)
            {
                lista.Remove(e);
            }
            var listaEventosVm = Mapeador.ConstruirListaEventosVm(lista);
            return listaEventosVm;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult ChoiseEvent(Carrito carrito)
        {
            if (!ModelState.IsValid)
            {
                carrito.Eventos = ConstruirListaEventosSinSuspender();
                carrito.Horarios = new List<HorarioListVm>();
                carrito.Localidades = new List<LocalidadListVm>();
                carrito.EventoId = -1;
                carrito.HorarioId = -1;
                return View(carrito);
            }
            var evento = _servicioEventos.GetTEntityPorId(carrito.EventoId);
            if (evento==null)
            {
                carrito.Eventos = ConstruirListaEventosSinSuspender();
                carrito.EventoId = -1;
                carrito.Horarios = new List<HorarioListVm>();
                carrito.Localidades = new List<LocalidadListVm>();
                carrito.HorarioId = -1;
                return View(carrito);
            }
            var listaHorariosVm =Mapeador.ConstruirListaHorarioVm( _servicioHorarios.GetLista(evento));
            foreach (var h in listaHorariosVm)
            {
                h.SetearFechaYHora();
            }
            carrito.Horarios = listaHorariosVm;
            if (carrito.HorarioId<=0 && carrito.EventoId>0)
            {
                carrito.Eventos = ConstruirListaEventosSinSuspender();
                carrito.HorarioId = -1;
                carrito.Localidades = new List<LocalidadListVm>();
                return View(carrito);
            }
            carrito.Localidades =Mapeador.ConstruirListaLocalidadesVm(_servicioLocalidades.GetLista());
            var tickets = _servicioTickets.GetLista(evento);
            var listaLocalidadesBorrar = new List<LocalidadListVm>();
            foreach (var t in tickets)
            {
                if (carrito.HorarioId==t.HorarioId)
                {
                    var l = _servicioLocalidades.GetLocalidadPorId(t.LocalidadId);
                    foreach (var loc in carrito.Localidades)
                    {
                        if (loc.LocalidadId==l.LocalidadId)
                        {
                            listaLocalidadesBorrar.Add(loc);
                        }
                    }
                    foreach (var lBorrar in listaLocalidadesBorrar)
                    {
                        carrito.Localidades.Remove(lBorrar);
                    }
                }
            }
            foreach (var l in carrito.Localidades)
            {
                l.SetearDetalles();
            }
            carrito.Eventos = ConstruirListaEventosSinSuspender();
            return View(carrito);
        }

    }
}