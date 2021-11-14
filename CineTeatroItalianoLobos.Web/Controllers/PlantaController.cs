using CineTeatroItalianoLobos.Services.Facades;
using CineTeatroItalianoLobos.Web.Clases;
using CineTeatroItalianoLobos.Web.Models.Planta;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CineTeatroItalianoLobos.Web.Controllers
{
    public class PlantaController : Controller
    {
        private readonly IPlantasServicio _servicio;
        private readonly ILocalidadesServicio _servicioLocalidades;
        private readonly int cantidadPorPaginas = 12;
        public PlantaController(IPlantasServicio servicio,
            ILocalidadesServicio servicioLocalidades)
        {
            _servicio = servicio;
            _servicioLocalidades = servicioLocalidades;
        }
        public ActionResult Index(int? page = null)
        {
            page = (page ?? 1);
            var lista = _servicio.GetLista();
            var listaVm = Mapeador.ConstruirListaPlantaVm(lista);
            foreach (var plantaVm in listaVm)
            {
                plantaVm.CantidadLocalidades = _servicioLocalidades.GetCantidad(e => e.PlantaId == plantaVm.PlantaId);
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
        public ActionResult Create(PlantaEditVm plantaEditVm)
        {
            if (!ModelState.IsValid)
            {
                return View(plantaEditVm);
            }
            var planta = Mapeador.ConstruirPlanta(plantaEditVm);
            try
            {
                if (_servicio.Existe(planta))
                {
                    ModelState.AddModelError(string.Empty, "Planta existente");
                    return View(plantaEditVm);
                }
                _servicio.Guardar(planta);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(plantaEditVm);
            }
        }


        [HttpGet]

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var planta = _servicio.GetTEntityPorId(id.Value);
            if (planta == null)
            {
                return new HttpNotFoundResult("Codigo de Planta inexistente");
            }
            var plantaEditVm = Mapeador.ConstruirPlantaEditVm(planta);
            return View(plantaEditVm);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PlantaEditVm plantaEditVm)
        {
            if (!ModelState.IsValid)
            {
                return View(plantaEditVm);
            }
            var planta = Mapeador.ConstruirPlanta(plantaEditVm);
            try
            {
                if (_servicio.Existe(planta))
                {
                    ModelState.AddModelError(string.Empty, "Planta existente");
                    return View(plantaEditVm);
                }
                _servicio.Guardar(planta);
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(plantaEditVm);
            }
        }
        [HttpGet]

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var planta = _servicio.GetTEntityPorId(id.Value);
            if (planta == null)
            {
                return new HttpNotFoundResult("Codigo de Planta inexistente");
            }
            var plantaVm = Mapeador.ConstruirPlantaListVm(planta);
            return View(plantaVm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var planta = _servicio.GetTEntityPorId(id);
            var plantaVm = Mapeador.ConstruirPlantaListVm(planta);
            if (_servicio.EstaRelacionado(planta))
            {

                ModelState.AddModelError(string.Empty, "Planta relacionada");
                return View(plantaVm);
            }
            try
            {
                _servicio.Borrar(id);
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(plantaVm);
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var planta = _servicio.GetTEntityPorId(id.Value);
            if (planta == null)
            {
                return HttpNotFound("Codigo de Planta Inexistente");
            }
            var plantaDetailsVm = Mapeador.ConstruirPlantaDetail(planta);
            plantaDetailsVm.CantidadLocalidades = _servicioLocalidades.GetCantidad(e => e.PlantaId == planta.PlantaId);
            plantaDetailsVm.Localidades = Mapeador.ConstruirListaLocalidadesVm(_servicioLocalidades.Find(e => e.PlantaId == planta.PlantaId, null, null));
            return View(plantaDetailsVm);
        }

    }
}