using CineTeatroItalianoLobos.Services.Facades;
using CineTeatroItalianoLobos.Web.Clases;
using CineTeatroItalianoLobos.Web.Models.Empleado;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CineTeatroItalianoLobos.Web.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly IEmpleadosServicio _servicio;
        private readonly ITiposDocumentosServicio _servicioTiposDocumentos;
        private readonly int cantidadPorPaginas = 12;
        public EmpleadoController(IEmpleadosServicio servicio
            , ITiposDocumentosServicio servicioTiposDocumentos)
        {
            _servicio = servicio;
            _servicioTiposDocumentos = servicioTiposDocumentos;
        }
        public ActionResult Index(int? page = null)
        {
            page = (page ?? 1);
            var lista = _servicio.GetLista();
            var listaVm = Mapeador.ConstruirListaEmpleadosVm(lista);
            return View(listaVm.ToPagedList((int)page, cantidadPorPaginas));
        }

        [HttpGet]

        public ActionResult Create()
        {
            EmpleadoEditVm empleadoEditVm = new EmpleadoEditVm()
            {
                TiposDocumentos =Mapeador.ConstruirListaTipoDocumentoVm(_servicioTiposDocumentos.GetLista())
            };
            return View(empleadoEditVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmpleadoEditVm empleadoEditVm)
        {
            if (!ModelState.IsValid)
            {
                empleadoEditVm.TiposDocumentos =
                    Mapeador.ConstruirListaTipoDocumentoVm(_servicioTiposDocumentos.GetLista());
            return View(empleadoEditVm);
            }
            var empleado = Mapeador.ContruirEmpleado(empleadoEditVm);
            try
            {
                if (_servicio.Existe(empleado))
                {
                    ModelState.AddModelError(string.Empty, "Empleado existente");
                    empleadoEditVm.TiposDocumentos =
               Mapeador.ConstruirListaTipoDocumentoVm(_servicioTiposDocumentos.GetLista());
                    return View(empleadoEditVm);
                }
                _servicio.Guardar(empleado);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                empleadoEditVm.TiposDocumentos =
               Mapeador.ConstruirListaTipoDocumentoVm(_servicioTiposDocumentos.GetLista());
                return View(empleadoEditVm);
            }
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var empleado = _servicio.GetTEntityPorId(id.Value);
            if (empleado == null)
            {
                return new HttpNotFoundResult("Codigo de Empleado inexistente");
            }
            var empleadoEditVm = Mapeador.ConstruirEmpleadoEditVm(empleado);
            empleadoEditVm.TiposDocumentos =
               Mapeador.ConstruirListaTipoDocumentoVm(_servicioTiposDocumentos.GetLista());
            return View(empleadoEditVm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmpleadoEditVm empleadoEditVm)
        {
            if (!ModelState.IsValid)
            {
                empleadoEditVm.TiposDocumentos =
               Mapeador.ConstruirListaTipoDocumentoVm(_servicioTiposDocumentos.GetLista());
                return View(empleadoEditVm);
            }
            var empleado = Mapeador.ContruirEmpleado(empleadoEditVm);
            try
            {
                if (_servicio.Existe(empleado))
                {
                    ModelState.AddModelError(string.Empty, "Empleado existente");
                    empleadoEditVm.TiposDocumentos =
               Mapeador.ConstruirListaTipoDocumentoVm(_servicioTiposDocumentos.GetLista());
                    return View(empleadoEditVm);
                }
                _servicio.Guardar(empleado);
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                empleadoEditVm.TiposDocumentos =
               Mapeador.ConstruirListaTipoDocumentoVm(_servicioTiposDocumentos.GetLista());
                return View(empleadoEditVm);
            }
        }
        [HttpGet]

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var empleado = _servicio.GetTEntityPorId(id.Value);
            if (empleado == null)
            {
                return new HttpNotFoundResult("Codigo de Empleado inexistente");
            }
            var empleadoVm = Mapeador.ConstruirEmpleadoListVm(empleado);
            return View(empleadoVm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var empleado = _servicio.GetTEntityPorId(id);
            var empleadoVm = Mapeador.ConstruirEmpleadoListVm(empleado);
            if (_servicio.EstaRelacionado(empleado))
            {

                ModelState.AddModelError(string.Empty, "Empleado relacionada");
                return View(empleadoVm);
            }
            try
            {
                _servicio.Borrar(id);
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(empleadoVm);
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var empleado = _servicio.GetTEntityPorId(id.Value);
            if (empleado == null)
            {
                return HttpNotFound("Codigo de Empleado Inexistente");
            }
            empleado.TipoDocumento=_servicioTiposDocumentos.GetTEntityPorId(empleado.TipoDocumentoId);
            var empleadoDetailsVm = Mapeador.ConstruirEmpleadoDetailsVm(empleado);
            return View(empleadoDetailsVm);
        }

    }
}