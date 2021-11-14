using CineTeatroItalianoLobos.Services.Facades;
using CineTeatroItalianoLobos.Web.Clases;
using CineTeatroItalianoLobos.Web.Models.Distribucion;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CineTeatroItalianoLobos.Web.Controllers
{
    public class DistribucionController : Controller
    {
        private readonly IDistribucionesServicio _servicio;
        private readonly IEventosServicios _servicioEventos;
        private readonly int cantidadPorPaginas = 12;
        public DistribucionController(IDistribucionesServicio servicio,
            IEventosServicios servicioEventos)
        {
            _servicio = servicio;
            _servicioEventos = servicioEventos;
        }
        public ActionResult Index(int? page = null)
        {
            page = (page ?? 1);
            var lista = _servicio.GetLista();
            var listaVm = Mapeador.ConstruirListaDistribucionVm(lista);
            foreach (var distribucionVm in listaVm)
            {
                distribucionVm.CantidadEventos = _servicioEventos.GetCantidad(e => e.DistribucionId == distribucionVm.DistribucionId);
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
        public ActionResult Create(DistribucionEditVm distribucionEditVm)
        {
            if (!ModelState.IsValid)
            {
                return View(distribucionEditVm);
            }
            var distribucion = Mapeador.ContruirDistribucion(distribucionEditVm);
            try
            {
                if (_servicio.Existe(distribucion))
                {
                    ModelState.AddModelError(string.Empty, "Distribucion existente");
                    return View(distribucionEditVm);
                }
                _servicio.Guardar(distribucion);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(distribucionEditVm);
            }
        }


        [HttpGet]

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var distribucion = _servicio.GetTEntityPorId(id.Value);
            if (distribucion == null)
            {
                return new HttpNotFoundResult("Codigo de Distribucion inexistente");
            }
            var distribucionEditVm = Mapeador.ConstruirDistribucionEditVm(distribucion);
            return View(distribucionEditVm);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DistribucionEditVm distribucionEditVm)
        {
            if (!ModelState.IsValid)
            {
                return View(distribucionEditVm);
            }
            var distribucion = Mapeador.ContruirDistribucion(distribucionEditVm);
            try
            {
                if (_servicio.Existe(distribucion))
                {
                    ModelState.AddModelError(string.Empty, "Distribucion existente");
                    return View(distribucionEditVm);
                }
                _servicio.Guardar(distribucion);
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(distribucionEditVm);
            }
        }
        [HttpGet]

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var distribucion = _servicio.GetTEntityPorId(id.Value);
            if (distribucion == null)
            {
                return new HttpNotFoundResult("Codigo de Distribucion inexistente");
            }
            var distribucionVm = Mapeador.ConstruirDistribucionListVm(distribucion);
            return View(distribucionVm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var distribucion = _servicio.GetTEntityPorId(id);
            var distribucionVm = Mapeador.ConstruirDistribucionListVm(distribucion);
            if (_servicio.EstaRelacionado(distribucion))
            {

                ModelState.AddModelError(string.Empty, "Distribucion relacionada");
                return View(distribucionVm);
            }
            try
            {
                _servicio.Borrar(id);
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(distribucionVm);
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var distribucion = _servicio.GetTEntityPorId(id.Value);
            if (distribucion == null)
            {
                return HttpNotFound("Codigo de Distribucion Inexistente");
            }
            var distribucionDetailsVm = Mapeador.ConstruirDistribucionDetailsVm(distribucion);
            distribucionDetailsVm.CantidadEventos = _servicioEventos.GetCantidad(e => e.DistribucionId == distribucion.DistribucionId);
            distribucionDetailsVm.Eventos = Mapeador.ConstruirListaEventosVm(_servicioEventos.Find(e => e.DistribucionId == distribucion.DistribucionId, null, null));
            return View(distribucionDetailsVm);
        }
    }
}