using CineTeatroItalianoLobos.Entities;
using CineTeatroItalianoLobos.Services.Facades;
using CineTeatroItalianoLobos.Web.Clases;
using CineTeatroItalianoLobos.Web.Models.Evento;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CineTeatroItalianoLobos.Web.Controllers
{
    public class HorarioController : Controller
    {
        private readonly IHorariosServicio _servicio;
        private readonly ITicketsServicio _servicioTickets;
        private readonly IEventosServicios _servicioEventos;
        private readonly int cantidadPorPaginas = 12;
        public HorarioController(IHorariosServicio servicio,
            ITicketsServicio servicioTickets, IEventosServicios servicioEventos)
        {
            _servicio = servicio;
            _servicioTickets = servicioTickets;
            _servicioEventos = servicioEventos;
        }
        public ActionResult Index(int? eventoSeleccionadoId = null, int? page = null)
        {
            page = (page ?? 1);
            if (eventoSeleccionadoId != null)
            {
                Session["eventoSeleccionadoId"] = eventoSeleccionadoId;
            }
            else
            {
                if (Session["eventoSeleccionadoId"] != null)
                {
                    eventoSeleccionadoId = (int)Session["eventoSeleccionadoId"];
                }
            }
            List<Horario> lista;
            if (eventoSeleccionadoId != null)
            {
                if (eventoSeleccionadoId.Value > 0)
                {
                    var e = _servicioEventos.GetTEntityPorId(eventoSeleccionadoId.Value);
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
            var listaVm = Mapeador.ConstruirListaHorarioVm(lista);
            foreach (var horarioVm in listaVm)
            {
                horarioVm.CantidadTickets = _servicioTickets.GetCantidad(t => t.HorarioId == horarioVm.HorarioId);
            }
            var listaEventos = _servicioEventos.GetLista();
            listaEventos.Insert(0, new Evento() { EventoId = 0, NombreEvento = "[Seleccione un Evento]" });
            listaEventos.Insert(1, new Evento() { EventoId = -1, NombreEvento = "[Ver Todos]" });

            ViewBag.Eventos = new SelectList(listaEventos, "EventoId", "NombreEvento", eventoSeleccionadoId);


            return View(listaVm.ToPagedList((int)page, cantidadPorPaginas));
        }
    }
}