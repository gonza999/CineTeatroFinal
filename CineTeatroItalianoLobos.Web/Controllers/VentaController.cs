using CineTeatroItalianoLobos.Entities;
using CineTeatroItalianoLobos.Services.Facades;
using CineTeatroItalianoLobos.Web.Clases;
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
        private readonly int cantidadPorPaginas = 12;
        public VentaController(IVentasServicio servicio,
            IEmpleadosServicio servicioEmpleados,
            ITicketsServicio servicioTickets, IEventosServicios servicioEventos,
            IHorariosServicio servicioHorarios
            )
        {
            _servicio = servicio;
            _servicioEmpleados = servicioEmpleados;
            _servicioTickets = servicioTickets;
            _servicioEventos = servicioEventos;
            _servicioHorarios = servicioHorarios;
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
            var horarioEditVm = new HorarioEditVm();
            horarioEditVm.Eventos = ConstruirListaEventosSinSuspender();
            return View(horarioEditVm);
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

        public ActionResult ChoiseEvent(HorarioEditVm horarioEditVm)
        {
            if (!ModelState.IsValid)
            {
                horarioEditVm.Eventos = ConstruirListaEventosSinSuspender();
                return View(horarioEditVm);
            }
            var evento = _servicioEventos.GetTEntityPorId(horarioEditVm.EventoId);
            var listaHorariosVm =Mapeador.ConstruirListaHorarioVm( _servicioHorarios.GetLista(evento));
            foreach (var h in listaHorariosVm)
            {
                h.SetearFechaYHora();
            }
            var ticketEditVm = new TicketEditVm()
            {
                Horarios=listaHorariosVm
            };
            return View("ChoiseHorario", ticketEditVm);
        }
        [HttpPost]
        public ActionResult ChoiseHorario(TicketEditVm ticketEditVm)
        {
            return View();
        }

    }
}