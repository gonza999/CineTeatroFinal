using CineTeatroItalianoLobos.Services.Facades;
using CineTeatroItalianoLobos.Web.Clases;
using CineTeatroItalianoLobos.Web.Models.Clasificacion;
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
    public class ClasificacionController : Controller
    {
        private readonly IClasificacionesServicio _servicio;
        private readonly IEventosServicios _servicioEventos;
        private readonly ITiposDeEventosServicios _servicioTiposEventos;
        private readonly IDistribucionesServicio _servicioDistribuciones;
        private readonly int cantidadPorPaginas = 12;
        public ClasificacionController(IClasificacionesServicio servicio,
            IEventosServicios servicioEventos, ITiposDeEventosServicios servicioTiposEventos,
            IDistribucionesServicio servicioDistribuciones)
        {
            _servicio = servicio;
            _servicioEventos = servicioEventos;
            _servicioTiposEventos = servicioTiposEventos;
            _servicioDistribuciones = servicioDistribuciones;
        }
        public ActionResult Index(int? page = null)
        {
            page = (page ?? 1);
            var lista = _servicio.GetLista();
            var listaVm = Mapeador.ConstruirListaClasificacionVm(lista);
            foreach (var clasificacionVm in listaVm)
            {
                clasificacionVm.CantidadEventos = _servicioEventos.GetCantidad(e => e.ClasificacionId == clasificacionVm.ClasificacionId);
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
        public ActionResult Create(ClasificacionEditVm clasificacionEditVm)
        {
            if (!ModelState.IsValid)
            {
                return View(clasificacionEditVm);
            }
            var clasificacion = Mapeador.ContruirClasificacion(clasificacionEditVm);
            try
            {
                if (_servicio.Existe(clasificacion))
                {
                    ModelState.AddModelError(string.Empty, "Clasificacion existente");
                    return View(clasificacionEditVm);
                }
                _servicio.Guardar(clasificacion);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(clasificacionEditVm);
            }
        }


        [HttpGet]

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var clasificacion = _servicio.GetTEntityPorId(id.Value);
            if (clasificacion == null)
            {
                return new HttpNotFoundResult("Codigo de Clasificacion inexistente");
            }
            var clasificacionEditVm = Mapeador.ConstruirClasificacionEditVm(clasificacion);
            return View(clasificacionEditVm);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClasificacionEditVm clasificacionEditVm)
        {
            if (!ModelState.IsValid)
            {
                return View(clasificacionEditVm);
            }
            var clasificacion = Mapeador.ContruirClasificacion(clasificacionEditVm);
            try
            {
                if (_servicio.Existe(clasificacion))
                {
                    ModelState.AddModelError(string.Empty, "Clasificacion existente");
                    return View(clasificacionEditVm);
                }
                _servicio.Guardar(clasificacion);
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(clasificacionEditVm);
            }
        }
        [HttpGet]

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var clasificacion = _servicio.GetTEntityPorId(id.Value);
            if (clasificacion == null)
            {
                return new HttpNotFoundResult("Codigo de Clasificacion inexistente");
            }
            var clasificacionVm = Mapeador.ConstruirClasificacionListVm(clasificacion);
            return View(clasificacionVm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var clasificacion = _servicio.GetTEntityPorId(id);
            var clasificacionVm = Mapeador.ConstruirClasificacionListVm(clasificacion);
            if (_servicio.EstaRelacionado(clasificacion))
            {

                ModelState.AddModelError(string.Empty, "Clasificacion relacionada");
                return View(clasificacionVm);
            }
            try
            {
                _servicio.Borrar(id);
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(clasificacionVm);
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var clasificacion = _servicio.GetTEntityPorId(id.Value);
            if (clasificacion == null)
            {
                return HttpNotFound("Codigo de Clasificacion Inexistente");
            }
            var clasificacionDetailsVm = Mapeador.ConstruirClasificacionDetailsVm(clasificacion);
            clasificacionDetailsVm.CantidadEventos = _servicioEventos.GetCantidad(e => e.ClasificacionId == clasificacion.ClasificacionId);
            clasificacionDetailsVm.Eventos = Mapeador.ConstruirListaEventosVm(_servicioEventos.Find(e => e.ClasificacionId == clasificacion.ClasificacionId, null, null));
            return View(clasificacionDetailsVm);
        }

        public ActionResult AddEvento(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var clasificacion = _servicio.GetTEntityPorId(id.Value);
            if (clasificacion == null)
            {
                return HttpNotFound("Código de clasificacion inexistente!!!");
            }

            var eventoEditVm = new EventoEditVm()
            {
                ClasificacionId = clasificacion.ClasificacionId,
                Clasificacion = Mapeador.ConstruirClasificacionListVm(clasificacion),
                TiposEventos = Mapeador.ConstruirListaTipoEventoVm(_servicioTiposEventos.GetLista()),
                Distribuciones = Mapeador.ConstruirListaDistribucionVm(_servicioDistribuciones.GetLista())
            };
            return View(eventoEditVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEvento(EventoEditVm eventoEditVm)
        {
            if (!ModelState.IsValid)
            {
                var clasificacion = Mapeador.ConstruirClasificacionListVm(_servicio.GetTEntityPorId(eventoEditVm.ClasificacionId));
                eventoEditVm.Clasificacion = clasificacion;
                eventoEditVm.TiposEventos = Mapeador.ConstruirListaTipoEventoVm(_servicioTiposEventos.GetLista());
                eventoEditVm.Distribuciones = Mapeador.ConstruirListaDistribucionVm(_servicioDistribuciones.GetLista());
                return View(eventoEditVm);
            }

            var evento = Mapeador.ConstruirEvento(eventoEditVm);
            try
            {
                if (_servicioEventos.Existe(evento))
                {
                    var clasificacion = Mapeador.ConstruirClasificacionListVm(_servicio.GetTEntityPorId(eventoEditVm.ClasificacionId));
                    eventoEditVm.Clasificacion = clasificacion;
                    eventoEditVm.TiposEventos = Mapeador.ConstruirListaTipoEventoVm(_servicioTiposEventos.GetLista());
                    eventoEditVm.Distribuciones = Mapeador.ConstruirListaDistribucionVm(_servicioDistribuciones.GetLista());
                    ModelState.AddModelError(string.Empty, "Evento existente!!!");
                    return View(eventoEditVm);
                }
                evento.FechaEvento = DateTime.Now;
                _servicioEventos.Guardar(evento);
                return RedirectToAction($"Details/{evento.ClasificacionId}");
            }
            catch (Exception e)
            {
                var clasificacion = Mapeador.ConstruirClasificacionListVm(_servicio.GetTEntityPorId(eventoEditVm.ClasificacionId));
                eventoEditVm.Clasificacion = clasificacion;
                eventoEditVm.TiposEventos = Mapeador.ConstruirListaTipoEventoVm(_servicioTiposEventos.GetLista());
                eventoEditVm.Distribuciones = Mapeador.ConstruirListaDistribucionVm(_servicioDistribuciones.GetLista());
                ModelState.AddModelError(string.Empty, e.Message);
                return View(eventoEditVm);
            }
        }

    }
}