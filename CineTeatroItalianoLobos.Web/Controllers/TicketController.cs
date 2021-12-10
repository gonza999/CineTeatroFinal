using CineTeatroItalianoLobos.Entities;
using CineTeatroItalianoLobos.Services.Facades;
using CineTeatroItalianoLobos.Web.Clases;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CineTeatroItalianoLobos.Web.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketsServicio _servicio;
        private readonly IEventosServicios _servicioEventos;
        private readonly int cantidadPorPaginas = 12;
        public TicketController(ITicketsServicio servicio,
            IEventosServicios servicioEventos)
        {
            _servicio = servicio;
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
            List<Ticket> lista;
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
            var listaVm = Mapeador.ConstruirListaTicketVm(lista);
            var listaEventos = _servicioEventos.GetLista();
            listaEventos.Insert(0, new Evento() { EventoId = 0, NombreEvento = "[Seleccione un Evento]" });
            listaEventos.Insert(1, new Evento() { EventoId = -1, NombreEvento = "[Ver Todos]" });

            ViewBag.Eventos = new SelectList(listaEventos, "EventoId", "NombreEvento", eventoSeleccionadoId);


            return View(listaVm.ToPagedList((int)page, cantidadPorPaginas));
        }
    }
}