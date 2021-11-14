using CineTeatroItalianoLobos.Services.Facades;
using CineTeatroItalianoLobos.Web.Clases;
using CineTeatroItalianoLobos.Web.Models.Ubicacion;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CineTeatroItalianoLobos.Web.Controllers
{
    public class UbicacionController : Controller
    {
        private readonly IUbicacionesServicio _servicio;
        private readonly ILocalidadesServicio _servicioLocalidades;
        private readonly int cantidadPorPaginas = 12;
        public UbicacionController(IUbicacionesServicio servicio,
            ILocalidadesServicio servicioLocalidades)
        {
            _servicio = servicio;
            _servicioLocalidades = servicioLocalidades;
        }
        public ActionResult Index(int? page = null)
        {
            page = (page ?? 1);
            var lista = _servicio.GetLista();
            var listaVm = Mapeador.ConstruirListaUbicacionVm(lista);
            foreach (var ubicacionVm in listaVm)
            {
                ubicacionVm.CantidadLocalidades = _servicioLocalidades.GetCantidad(e => e.UbicacionId == ubicacionVm.UbicacionId);
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
        public ActionResult Create(UbicacionEditVm ubicacionEditVm)
        {
            if (!ModelState.IsValid)
            {
                return View(ubicacionEditVm);
            }
            var ubicacion = Mapeador.ConstruirUbicacion(ubicacionEditVm);
            try
            {
                if (_servicio.Existe(ubicacion))
                {
                    ModelState.AddModelError(string.Empty, "Tipo de Localidad existente");
                    return View(ubicacionEditVm);
                }
                _servicio.Guardar(ubicacion);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(ubicacionEditVm);
            }
        }


        [HttpGet]

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ubicacion = _servicio.GetTEntityPorId(id.Value);
            if (ubicacion == null)
            {
                return new HttpNotFoundResult("Codigo de Ubicacion inexistente");
            }
            var ubicacionEditVm = Mapeador.ConstruirUbicacionEditVm(ubicacion);
            return View(ubicacionEditVm);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UbicacionEditVm ubicacionEditVm)
        {
            if (!ModelState.IsValid)
            {
                return View(ubicacionEditVm);
            }
            var ubicacion = Mapeador.ConstruirUbicacion(ubicacionEditVm);
            try
            {
                if (_servicio.Existe(ubicacion))
                {
                    ModelState.AddModelError(string.Empty, "Ubicacion existente");
                    return View(ubicacionEditVm);
                }
                _servicio.Guardar(ubicacion);
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(ubicacionEditVm);
            }
        }
        [HttpGet]

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ubicacion = _servicio.GetTEntityPorId(id.Value);
            if (ubicacion == null)
            {
                return new HttpNotFoundResult("Codigo de Ubicacion inexistente");
            }
            var ubicacionVm = Mapeador.ConstruirUbicacionListVm(ubicacion);
            return View(ubicacionVm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var ubicacion = _servicio.GetTEntityPorId(id);
            var ubicacionVm = Mapeador.ConstruirUbicacionListVm(ubicacion);
            if (_servicio.EstaRelacionado(ubicacion))
            {

                ModelState.AddModelError(string.Empty, "Ubicacion relacionada");
                return View(ubicacionVm);
            }
            try
            {
                _servicio.Borrar(id);
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(ubicacionVm);
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ubicacion = _servicio.GetTEntityPorId(id.Value);
            if (ubicacion == null)
            {
                return HttpNotFound("Codigo de Ubicacion Inexistente");
            }
            var ubicacionDetailsVm = Mapeador.ConstruirUbicacionDetail(ubicacion);
            ubicacionDetailsVm.CantidadLocalidades = _servicioLocalidades.GetCantidad(e => e.UbicacionId == ubicacion.UbicacionId);
            ubicacionDetailsVm.Localidades = Mapeador.ConstruirListaLocalidadesVm(_servicioLocalidades.Find(e => e.UbicacionId == ubicacion.UbicacionId, null, null));
            return View(ubicacionDetailsVm);
        }

    }
}