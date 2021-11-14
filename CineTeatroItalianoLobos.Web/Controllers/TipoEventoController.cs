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

namespace CineTeatroItalianoLobos.Web.Controllers
{
    public class TipoEventoController : Controller
    {
        private readonly ITiposDeEventosServicios _servicio;
        private readonly IEventosServicios _servicioEventos;
        private readonly int cantidadPorPaginas = 12;
        public TipoEventoController(ITiposDeEventosServicios servicio,
            IEventosServicios servicioEventos)
        {
            _servicio = servicio;
            _servicioEventos = servicioEventos;
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

        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var tipoEvento = _servicio.GetTEntityPorId(id.Value);
        //    if (tipoEvento == null)
        //    {
        //        return HttpNotFound("Codigo de TipoEvento Inexistente");
        //    }
        //    var tipoEventoDetailsVm = Mapeador.ConstruirTipoEventoDetailsVm(tipoEvento);
        //    tipoEventoDetailsVm.CantidadEventos = _servicioEventos.GetCantidad(p => p.TipoEventoId == tipoEvento.TipoEventoId);
        //    tipoEventoDetailsVm.Eventos = Mapeador.ConstruirListaEventosVm(_servicioEventos.Find(p => p.TipoEventoId == tipoEvento.TipoEventoId, null, null));
        //    return View(tipoEventoDetailsVm);
        //}

        //public ActionResult AddEvento(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var tipoEvento = _servicio.GetTEntityPorId(id.Value);
        //    if (tipoEvento == null)
        //    {
        //        return HttpNotFound("Codigo de TipoEvento Inexistente");
        //    }
        //    var eventoEditVm = new EventoEditVm()
        //    {
        //        TipoEventoId = tipoEvento.TipoEventoId,
        //        TipoEvento = Mapeador.ConstruirTipoEventoVm(tipoEvento)
        //    };
        //    return View(eventoEditVm);
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult AddEvento(EventoEditVm eventoEditVm)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var tipoEvento = _servicio.GetTEntityPorId(eventoEditVm.TipoEventoId);
        //        eventoEditVm.TipoEvento = Mapeador.ConstruirTipoEventoVm(tipoEvento);
        //        return View(eventoEditVm);
        //    }
        //    var evento = Mapeador.ConstruirEvento(eventoEditVm);
        //    try
        //    {
        //        if (_servicioEventos.Existe(evento))
        //        {
        //            var tipoEvento = _servicio.GetTEntityPorId(eventoEditVm.TipoEventoId);
        //            eventoEditVm.TipoEvento = Mapeador.ConstruirTipoEventoVm(tipoEvento);
        //            ModelState.AddModelError(string.Empty, "Evento existente");
        //            return View(eventoEditVm);
        //        }
        //        _servicioEventos.Guardar(evento);
        //        return RedirectToAction($"Details/{evento.TipoEventoId}");
        //    }
        //    catch (Exception e)
        //    {
        //        var tipoEvento = _servicio.GetTEntityPorId(eventoEditVm.TipoEventoId);
        //        eventoEditVm.TipoEvento = Mapeador.ConstruirTipoEventoVm(tipoEvento);
        //        ModelState.AddModelError(string.Empty, e.Message);
        //        return View(eventoEditVm);
        //    }
        //}

        //public ActionResult DeleteEvento(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var evento = _servicioEventos.GetTEntityPorId(id.Value);
        //    if (evento == null)
        //    {
        //        return HttpNotFound("Codigo de Evento Inexistente");
        //    }
        //    var eventoEditVm = Mapeador.ConstruirEventoEditVm(evento);
        //    var tipoEventoVm = Mapeador.ConstruirTipoEventoVm(evento.TipoEvento);
        //    eventoEditVm.TipoEvento = tipoEventoVm;
        //    return View(eventoEditVm);
        //}

        //[HttpPost, ActionName("DeleteEvento")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteEvento(int id)
        //{
        //    var evento = _servicioEventos.GetTEntityPorId(id);

        //    try
        //    {
        //        if (_servicioEventos.EstaRelacionado(evento))
        //        {
        //            var tipoEventoVm = Mapeador.ConstruirTipoEventoVm(_servicio.GetTEntityPorId(evento.TipoEventoId));
        //            var eventoEditVm = Mapeador.ConstruirEventoEditVm(evento);
        //            eventoEditVm.TipoEvento = tipoEventoVm;
        //            ModelState.AddModelError(string.Empty, "Evento Relacionado");
        //            return View(eventoEditVm);
        //        }
        //        _servicioEventos.Borrar(evento.EventoId);
        //        return RedirectToAction($"Details/{evento.TipoEventoId}");
        //    }
        //    catch (Exception e)
        //    {
        //        var tipoEventoVm = Mapeador.ConstruirTipoEventoVm(_servicio.GetTEntityPorId(evento.TipoEventoId));
        //        var eventoEditVm = Mapeador.ConstruirEventoEditVm(evento);
        //        eventoEditVm.TipoEvento = tipoEventoVm;
        //        ModelState.AddModelError(string.Empty, e.Message);
        //        return View(eventoEditVm);
        //    }
        //}

        //public ActionResult EditEvento(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var evento = _servicioEventos.GetTEntityPorId(id.Value);
        //    if (evento == null)
        //    {
        //        return new HttpNotFoundResult("Codigo de Evento inexistente");
        //    }
        //    var eventoEditVm = Mapeador.ConstruirEventoEditVm(evento);
        //    return View(eventoEditVm);
        //}



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult EditEvento(EventoEditVm eventoEditVm)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(eventoEditVm);
        //    }
        //    var evento = Mapeador.ConstruirEvento(eventoEditVm);
        //    try
        //    {
        //        if (_servicioEventos.Existe(evento))
        //        {
        //            ModelState.AddModelError(string.Empty, "Evento existente");
        //            return View(eventoEditVm);
        //        }
        //        _servicioEventos.Guardar(evento);
        //        return RedirectToAction("Index");

        //    }
        //    catch (Exception e)
        //    {
        //        ModelState.AddModelError(string.Empty, e.Message);
        //        return View(eventoEditVm);
        //    }
        //}
    }
}