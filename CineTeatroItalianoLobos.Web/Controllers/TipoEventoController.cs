using CineTeatroItalianoLobos.Services.Facades;
using CineTeatroItalianoLobos.Web.Clases;
using CineTeatroItalianoLobos.Web.Models.TipoEvento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using CineTeatroItalianoLobos.Web.Models.Evento;

namespace CineTeatroItalianoLobos.Web.Controllers
{
    public class TipoEventoController : Controller
    {
        private readonly ITiposDeEventosServicios _servicio;
        private readonly IEventosServicios _servicioEventos;
        private readonly IClasificacionesServicio _servicioClasificaciones;
        private readonly IDistribucionesServicio _servicioDistribuciones;
        private readonly int cantidadPorPaginas = 12;
        public TipoEventoController(ITiposDeEventosServicios servicio,
            IEventosServicios servicioEventos, IDistribucionesServicio servicioDistribuciones,
            IClasificacionesServicio servicioClasificaciones)
        {
            _servicio = servicio;
            _servicioEventos = servicioEventos;
            _servicioClasificaciones = servicioClasificaciones;
            _servicioDistribuciones = servicioDistribuciones;
        }
        public ActionResult Index(int? page = null)
        {
            page = (page ?? 1);
            var lista = _servicio.GetLista();
            var listaVm = Mapeador.ConstruirListaTipoEventoVm(lista);
            foreach (var tipoEventoVm in listaVm)
            {
                tipoEventoVm.CantidadEventos = _servicioEventos.GetCantidad(e => e.TipoEventoId == tipoEventoVm.TipoEventoId);
            }
            return View(listaVm.ToPagedList((int)page, cantidadPorPaginas));
        }

        [HttpGet]

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoEventoEditVm tipoEventoEditVm)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoEventoEditVm);
            }
            var tipoEvento = Mapeador.ContruirTipoEvento(tipoEventoEditVm);
            try
            {
                if (_servicio.Existe(tipoEvento))
                {
                    ModelState.AddModelError(string.Empty, "Tipo de Evento existente");
                    return View(tipoEventoEditVm);
                }
                _servicio.Guardar(tipoEvento);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(tipoEventoEditVm);
            }
        }


        [HttpGet]

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tipoEvento = _servicio.GetTEntityPorId(id.Value);
            if (tipoEvento == null)
            {
                return new HttpNotFoundResult("Codigo de TipoEvento inexistente");
            }
            var tipoEventoEditVm = Mapeador.ConstruirTipoEventoEditVm(tipoEvento);
            return View(tipoEventoEditVm);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoEventoEditVm tipoEventoEditVm)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoEventoEditVm);
            }
            var tipoEvento = Mapeador.ContruirTipoEvento(tipoEventoEditVm);
            try
            {
                if (_servicio.Existe(tipoEvento))
                {
                    ModelState.AddModelError(string.Empty, "TipoEvento existente");
                    return View(tipoEventoEditVm);
                }
                _servicio.Guardar(tipoEvento);
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(tipoEventoEditVm);
            }
        }
        [HttpGet]

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tipoEvento = _servicio.GetTEntityPorId(id.Value);
            if (tipoEvento == null)
            {
                return new HttpNotFoundResult("Codigo de TipoEvento inexistente");
            }
            var tipoEventoVm = Mapeador.ConstruirTipoEventoListVm(tipoEvento);
            return View(tipoEventoVm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var tipoEvento = _servicio.GetTEntityPorId(id);
            var tipoEventoVm = Mapeador.ConstruirTipoEventoListVm(tipoEvento);
            if (_servicio.EstaRelacionado(tipoEvento))
            {

                ModelState.AddModelError(string.Empty, "TipoEvento relacionada");
                return View(tipoEventoVm);
            }
            try
            {
                _servicio.Borrar(id);
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(tipoEventoVm);
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tipoEvento = _servicio.GetTEntityPorId(id.Value);
            if (tipoEvento == null)
            {
                return HttpNotFound("Codigo de TipoEvento Inexistente");
            }
            var tipoEventoDetailsVm = Mapeador.ConstruirTipoEventoDetailsVm(tipoEvento);
            tipoEventoDetailsVm.CantidadEventos = _servicioEventos.GetCantidad(e => e.TipoEventoId == tipoEvento.TipoEventoId);
            tipoEventoDetailsVm.Eventos = Mapeador.ConstruirListaEventosVm(_servicioEventos.Find(e=>e.TipoEventoId==tipoEvento.TipoEventoId,null,null));
            return View(tipoEventoDetailsVm);
        }

        public ActionResult AddEvento(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var tipoEvento = _servicio.GetTEntityPorId(id.Value);
            if (tipoEvento == null)
            {
                return HttpNotFound("Código del Tipo de evento inexistente!!!");
            }

            var eventoEditVm = new EventoEditVm()
            {
                TipoEventoId = tipoEvento.TipoEventoId,
                TipoEvento = Mapeador.ConstruirTipoEventoListVm(tipoEvento),
                Distribuciones = Mapeador.ConstruirListaDistribucionVm(_servicioDistribuciones.GetLista()),
                Clasificaciones = Mapeador.ConstruirListaClasificacionVm(_servicioClasificaciones.GetLista())
            };
            return View(eventoEditVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEvento(EventoEditVm eventoEditVm)
        {
            if (!ModelState.IsValid)
            {
                var tipoEvento = Mapeador.ConstruirTipoEventoListVm(_servicio.GetTEntityPorId(eventoEditVm.TipoEventoId));
                eventoEditVm.TipoEvento = tipoEvento;
                eventoEditVm.Distribuciones = Mapeador.ConstruirListaDistribucionVm(_servicioDistribuciones.GetLista());
                eventoEditVm.Clasificaciones = Mapeador.ConstruirListaClasificacionVm(_servicioClasificaciones.GetLista());
                return View(eventoEditVm);
            }

            var evento = Mapeador.ConstruirEvento(eventoEditVm);
            try
            {
                if (_servicioEventos.Existe(evento))
                {
                    var tipoEvento = Mapeador.ConstruirTipoEventoListVm(_servicio.GetTEntityPorId(eventoEditVm.TipoEventoId));
                    eventoEditVm.TipoEvento = tipoEvento;
                    eventoEditVm.Distribuciones = Mapeador.ConstruirListaDistribucionVm(_servicioDistribuciones.GetLista());
                    eventoEditVm.Clasificaciones = Mapeador.ConstruirListaClasificacionVm(_servicioClasificaciones.GetLista());
                    ModelState.AddModelError(string.Empty, "Evento existente!!!");
                    return View(eventoEditVm);
                }
                evento.FechaEvento = DateTime.Now;
                _servicioEventos.Guardar(evento);
                return RedirectToAction($"Details/{evento.TipoEventoId}");
            }
            catch (Exception e)
            {
                var tipoEvento = Mapeador.ConstruirTipoEventoListVm(_servicio.GetTEntityPorId(eventoEditVm.TipoEventoId));
                eventoEditVm.TipoEvento = tipoEvento;
                eventoEditVm.Distribuciones = Mapeador.ConstruirListaDistribucionVm(_servicioDistribuciones.GetLista());
                eventoEditVm.Clasificaciones = Mapeador.ConstruirListaClasificacionVm(_servicioClasificaciones.GetLista());
                ModelState.AddModelError(string.Empty, e.Message);
                return View(eventoEditVm);
            }
        }
    }
}