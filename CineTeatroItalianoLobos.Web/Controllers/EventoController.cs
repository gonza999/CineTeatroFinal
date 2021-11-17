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
    public class EventoController : Controller
    {
        private readonly IEventosServicios _servicio;
        private readonly ITiposDeEventosServicios _servicioTiposEventos;
        private readonly IClasificacionesServicio _servicioClasificaciones;
        private readonly IDistribucionesServicio _servicioDistribuciones;
        private readonly int cantidadPorPaginas = 12;
        public EventoController(IEventosServicios servicio
            , ITiposDeEventosServicios servicioTiposEventos,
            IClasificacionesServicio servicioClasificaciones,
            IDistribucionesServicio servicioDistribuciones)
        {
            _servicio = servicio;
            _servicioTiposEventos = servicioTiposEventos;
            _servicioClasificaciones = servicioClasificaciones;
            _servicioDistribuciones = servicioDistribuciones;
        }
        public ActionResult Index(int? page = null)
        {
            page = (page ?? 1);
            var lista = _servicio.GetLista();
            var listaVm = Mapeador.ConstruirListaEventosVm(lista);
            return View(listaVm.ToPagedList((int)page, cantidadPorPaginas));
        }

        [HttpGet]

        public ActionResult Create()
        {
            EventoEditVm eventoEditVm = new EventoEditVm()
            {
                TiposEventos = Mapeador.ConstruirListaTipoEventoVm(_servicioTiposEventos.GetLista()),
                Clasificaciones=Mapeador.ConstruirListaClasificacionVm(_servicioClasificaciones.GetLista()),
                Distribuciones=Mapeador.ConstruirListaDistribucionVm(_servicioDistribuciones.GetLista())
            };
            return View(eventoEditVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventoEditVm eventoEditVm)
        {
            if (!ModelState.IsValid)
            {
                eventoEditVm.TiposEventos = Mapeador.ConstruirListaTipoEventoVm(_servicioTiposEventos.GetLista());
                eventoEditVm.Clasificaciones = Mapeador.ConstruirListaClasificacionVm(_servicioClasificaciones.GetLista());
                eventoEditVm.Distribuciones = Mapeador.ConstruirListaDistribucionVm(_servicioDistribuciones.GetLista());
                return View(eventoEditVm);
            }
            var evento = Mapeador.ConstruirEvento(eventoEditVm);
            try
            {
                if (_servicio.Existe(evento))
                {
                    ModelState.AddModelError(string.Empty, "Evento existente");
                    eventoEditVm.TiposEventos = Mapeador.ConstruirListaTipoEventoVm(_servicioTiposEventos.GetLista());
                    eventoEditVm.Clasificaciones = Mapeador.ConstruirListaClasificacionVm(_servicioClasificaciones.GetLista());
                    eventoEditVm.Distribuciones = Mapeador.ConstruirListaDistribucionVm(_servicioDistribuciones.GetLista());
                    return View(eventoEditVm);
                }
                evento.FechaEvento = DateTime.Now;
                _servicio.Guardar(evento);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                eventoEditVm.TiposEventos = Mapeador.ConstruirListaTipoEventoVm(_servicioTiposEventos.GetLista());
                eventoEditVm.Clasificaciones = Mapeador.ConstruirListaClasificacionVm(_servicioClasificaciones.GetLista());
                eventoEditVm.Distribuciones = Mapeador.ConstruirListaDistribucionVm(_servicioDistribuciones.GetLista());
                return View(eventoEditVm);
            }
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var evento = _servicio.GetTEntityPorId(id.Value);
            if (evento == null)
            {
                return new HttpNotFoundResult("Codigo de Evento inexistente");
            }
            var eventoEditVm = Mapeador.ConstruirEventoEditVm(evento);
            eventoEditVm.TiposEventos = Mapeador.ConstruirListaTipoEventoVm(_servicioTiposEventos.GetLista());
            eventoEditVm.Clasificaciones = Mapeador.ConstruirListaClasificacionVm(_servicioClasificaciones.GetLista());
            eventoEditVm.Distribuciones = Mapeador.ConstruirListaDistribucionVm(_servicioDistribuciones.GetLista());
            return View(eventoEditVm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EventoEditVm eventoEditVm)
        {
            if (!ModelState.IsValid)
            {
                eventoEditVm.TiposEventos = Mapeador.ConstruirListaTipoEventoVm(_servicioTiposEventos.GetLista());
                eventoEditVm.Clasificaciones = Mapeador.ConstruirListaClasificacionVm(_servicioClasificaciones.GetLista());
                eventoEditVm.Distribuciones = Mapeador.ConstruirListaDistribucionVm(_servicioDistribuciones.GetLista());
                return View(eventoEditVm);
            }
            var evento = Mapeador.ConstruirEvento(eventoEditVm);
            try
            {
                if (_servicio.Existe(evento))
                {
                    ModelState.AddModelError(string.Empty, "Evento existente");
                    eventoEditVm.TiposEventos = Mapeador.ConstruirListaTipoEventoVm(_servicioTiposEventos.GetLista());
                    eventoEditVm.Clasificaciones = Mapeador.ConstruirListaClasificacionVm(_servicioClasificaciones.GetLista());
                    eventoEditVm.Distribuciones = Mapeador.ConstruirListaDistribucionVm(_servicioDistribuciones.GetLista());
                    return View(eventoEditVm);
                }
                evento.FechaEvento = DateTime.Now;
                evento.TipoEvento = _servicioTiposEventos.GetTEntityPorId(evento.TipoEventoId);
                evento.Clasificacion = _servicioClasificaciones.GetTEntityPorId(evento.ClasificacionId);
                evento.Distribucion = _servicioDistribuciones.GetTEntityPorId(evento.DistribucionId);
                _servicio.Guardar(evento);
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                eventoEditVm.TiposEventos = Mapeador.ConstruirListaTipoEventoVm(_servicioTiposEventos.GetLista());
                eventoEditVm.Clasificaciones = Mapeador.ConstruirListaClasificacionVm(_servicioClasificaciones.GetLista());
                eventoEditVm.Distribuciones = Mapeador.ConstruirListaDistribucionVm(_servicioDistribuciones.GetLista());
                return View(eventoEditVm);
            }
        }
        [HttpGet]

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var evento = _servicio.GetTEntityPorId(id.Value);
            if (evento == null)
            {
                return new HttpNotFoundResult("Codigo de Evento inexistente");
            }
            var eventoVm = Mapeador.ConstruirEventoListVm(evento);
            return View(eventoVm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var evento = _servicio.GetTEntityPorId(id);
            var eventoVm = Mapeador.ConstruirEventoListVm(evento);
            if (_servicio.EstaRelacionado(evento))
            {

                ModelState.AddModelError(string.Empty, "Evento relacionada");
                return View(eventoVm);
            }
            try
            {
                _servicio.Borrar(id);
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(eventoVm);
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var evento = _servicio.GetTEntityPorId(id.Value);
            if (evento == null)
            {
                return HttpNotFound("Codigo de Evento Inexistente");
            }
            evento.TipoEvento = _servicioTiposEventos.GetTEntityPorId(evento.TipoEventoId);
            evento.Clasificacion = _servicioClasificaciones.GetTEntityPorId(evento.ClasificacionId);
            evento.Distribucion = _servicioDistribuciones.GetTEntityPorId(evento.DistribucionId);
            var eventoDetailsVm = Mapeador.ConstruirEventoDetailsVm(evento);
            return View(eventoDetailsVm);
        }
    }
}