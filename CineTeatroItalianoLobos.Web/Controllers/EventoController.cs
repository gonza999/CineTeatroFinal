using CineTeatroItalianoLobos.Entities;
using CineTeatroItalianoLobos.Services.Facades;
using CineTeatroItalianoLobos.Web.Clases;
using CineTeatroItalianoLobos.Web.Models.Evento;
using CineTeatroItalianoLobos.Web.Models.Horario;
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
        private readonly IHorariosServicio _servicioHorarios;
        private readonly int cantidadPorPaginas = 12;
        public EventoController(IEventosServicios servicio
            , ITiposDeEventosServicios servicioTiposEventos,
            IClasificacionesServicio servicioClasificaciones,
            IDistribucionesServicio servicioDistribuciones,
            IHorariosServicio servicioHorarios)
        {
            _servicio = servicio;
            _servicioTiposEventos = servicioTiposEventos;
            _servicioClasificaciones = servicioClasificaciones;
            _servicioDistribuciones = servicioDistribuciones;
            _servicioHorarios = servicioHorarios;
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
            var horarios = _servicioHorarios.GetLista(evento);
            var eventoDetailsVm = Mapeador.ConstruirEventoDetailsVm(evento,horarios);
            return View(eventoDetailsVm);
        }


        public ActionResult AddHorario(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var evento = _servicio.GetTEntityPorId(id.Value);
            if (evento == null)
            {
                return HttpNotFound("Código de evento inexistente!!!");
            }

            var horarioEditVm = new HorarioEditVm()
            {
                EventoId = evento.EventoId,
                Evento = Mapeador.ConstruirEventoEditVm(evento),
            };
            return View(horarioEditVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddHorario(HorarioEditVm horarioEditVm)
        {
            if (!ModelState.IsValid)
            {
                var evento = Mapeador.ConstruirEventoEditVm(_servicio.GetTEntityPorId(horarioEditVm.EventoId));
                horarioEditVm.Evento = evento;
                return View(horarioEditVm);
            }

            Horario horario = Mapeador.ConstruirHorario(horarioEditVm);
            try
            {
                if (_servicioHorarios.Existe(horario))
                {
                    var evento = Mapeador.ConstruirEventoEditVm(_servicio.GetTEntityPorId(horarioEditVm.EventoId));
                    horarioEditVm.Evento = evento;
                    ModelState.AddModelError(string.Empty, "Horario existente!!!");
                    return View(horarioEditVm);
                }
                horario.SetearFechaYHora();
                horario.Evento = _servicio.GetTEntityPorId(horario.EventoId);
                var lista = _servicioHorarios.GetLista(horario.Evento);
                foreach (var h in lista)
                {
                    h.SetearFechaYHora();
                    if (h.FechaYHora==horario.FechaYHora)
                    {
                        var evento = Mapeador.ConstruirEventoEditVm(_servicio.GetTEntityPorId(horarioEditVm.EventoId));
                        horarioEditVm.Evento = evento;
                        ModelState.AddModelError(string.Empty, "Horario existente!!!");
                        return View(horarioEditVm);
                    }
                }
                if (horario.Fecha<DateTime.Now)
                {
                    var evento = Mapeador.ConstruirEventoEditVm(_servicio.GetTEntityPorId(horarioEditVm.EventoId));
                    horarioEditVm.Evento = evento;
                    ModelState.AddModelError(string.Empty, "Horario denegado,la fecha debe ser posterior a la actual");
                    return View(horarioEditVm);
                }
                _servicioHorarios.Guardar(horario);
                return RedirectToAction($"Details/{horario.EventoId}");
            }
            catch (Exception e)
            {
                var evento = Mapeador.ConstruirEventoEditVm(_servicio.GetTEntityPorId(horarioEditVm.EventoId));
                horarioEditVm.Evento = evento;
                ModelState.AddModelError(string.Empty, e.Message);
                return View(horarioEditVm);
            }
        }
    }
}