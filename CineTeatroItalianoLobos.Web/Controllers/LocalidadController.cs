using CineTeatroItalianoLobos.Services.Facades;
using CineTeatroItalianoLobos.Web.Clases;
using CineTeatroItalianoLobos.Web.Models.Localidad;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CineTeatroItalianoLobos.Web.Controllers
{
    public class LocalidadController : Controller
    {
        private readonly ILocalidadesServicio _servicio;
        private readonly IPlantasServicio _servicioPlantas;
        private readonly IUbicacionesServicio _servicioUbicaciones;
        private readonly int cantidadPorPaginas = 12;
        public LocalidadController(ILocalidadesServicio servicio,
            IPlantasServicio servicioPlantas, IUbicacionesServicio servicioUbicaciones)
        {
            _servicio = servicio;
            _servicioPlantas = servicioPlantas;
            _servicioUbicaciones = servicioUbicaciones;
        }
        public ActionResult Index(int? page = null)
        {
            page = (page ?? 1);
            var lista = _servicio.GetLista();
            var listaVm = Mapeador.ConstruirListaLocalidadesVm(lista);
            return View(listaVm.ToPagedList((int)page, cantidadPorPaginas));
        }

        [HttpGet]

        public ActionResult Create()
        {
            LocalidadEditVm localidadEditVm = new LocalidadEditVm()
            {
                Plantas = Mapeador.ConstruirListaPlantaVm(_servicioPlantas.GetLista()),
                Ubicaciones = Mapeador.ConstruirListaUbicacionVm(_servicioUbicaciones.GetLista())
            };
            return View(localidadEditVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LocalidadEditVm localidadEditVm)
        {
            if (!ModelState.IsValid)
            {
                localidadEditVm.Plantas = Mapeador.ConstruirListaPlantaVm(_servicioPlantas.GetLista());
                localidadEditVm.Ubicaciones = Mapeador.ConstruirListaUbicacionVm(_servicioUbicaciones.GetLista());
                return View(localidadEditVm);
            }
            var localidad = Mapeador.ConstruirLocalidad(localidadEditVm);
            try
            {
                if (_servicio.Existe(localidad))
                {
                    localidadEditVm.Plantas = Mapeador.ConstruirListaPlantaVm(_servicioPlantas.GetLista());
                    localidadEditVm.Ubicaciones = Mapeador.ConstruirListaUbicacionVm(_servicioUbicaciones.GetLista());
                    ModelState.AddModelError(string.Empty, "Localidad existente");
                    return View(localidadEditVm);
                }
                _servicio.Guardar(localidad);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                localidadEditVm.Plantas = Mapeador.ConstruirListaPlantaVm(_servicioPlantas.GetLista());
                localidadEditVm.Ubicaciones = Mapeador.ConstruirListaUbicacionVm(_servicioUbicaciones.GetLista());
                ModelState.AddModelError(string.Empty, e.Message);
                return View(localidadEditVm);
            }
        }


        [HttpGet]

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var localidad = _servicio.GetLocalidadPorId(id.Value);
            if (localidad == null)
            {
                return new HttpNotFoundResult("Codigo de Localidad inexistente");
            }
            var localidadEditVm = Mapeador.ConstruirLocalidadEditVm(localidad);
            localidadEditVm.Plantas = Mapeador.ConstruirListaPlantaVm(_servicioPlantas.GetLista());
            localidadEditVm.Ubicaciones = Mapeador.ConstruirListaUbicacionVm(_servicioUbicaciones.GetLista());
            return View(localidadEditVm);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LocalidadEditVm localidadEditVm)
        {
            if (!ModelState.IsValid)
            {
                localidadEditVm.Plantas = Mapeador.ConstruirListaPlantaVm(_servicioPlantas.GetLista());
                localidadEditVm.Ubicaciones = Mapeador.ConstruirListaUbicacionVm(_servicioUbicaciones.GetLista());
                return View(localidadEditVm);
            }
            var localidad = Mapeador.ConstruirLocalidad(localidadEditVm);
            try
            {
                if (_servicio.Existe(localidad))
                {
                    localidadEditVm.Plantas = Mapeador.ConstruirListaPlantaVm(_servicioPlantas.GetLista());
                    localidadEditVm.Ubicaciones = Mapeador.ConstruirListaUbicacionVm(_servicioUbicaciones.GetLista());
                    ModelState.AddModelError(string.Empty, "Localidad existente");
                    return View(localidadEditVm);
                }
                _servicio.Guardar(localidad);
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                localidadEditVm.Plantas = Mapeador.ConstruirListaPlantaVm(_servicioPlantas.GetLista());
                localidadEditVm.Ubicaciones = Mapeador.ConstruirListaUbicacionVm(_servicioUbicaciones.GetLista());
                ModelState.AddModelError(string.Empty, e.Message);
                return View(localidadEditVm);
            }
        }
        [HttpGet]

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var localidad = _servicio.GetLocalidadPorId(id.Value);
            if (localidad == null)
            {
                return new HttpNotFoundResult("Codigo de Localidad inexistente");
            }
            var localidadVm = Mapeador.ConstruirLocalidadListVm(localidad);
            return View(localidadVm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var localidad = _servicio.GetLocalidadPorId(id);
            var localidadVm = Mapeador.ConstruirLocalidadListVm(localidad);
            if (_servicio.EstaRelacionado(localidad))
            {

                ModelState.AddModelError(string.Empty, "Localidad relacionada");
                return View(localidadVm);
            }
            try
            {
                _servicio.Borrar(id);
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(localidadVm);
            }
        }

    }
}