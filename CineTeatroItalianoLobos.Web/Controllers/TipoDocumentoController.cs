using CineTeatroItalianoLobos.Services;
using CineTeatroItalianoLobos.Services.Facades;
using CineTeatroItalianoLobos.Web.Clases;
using CineTeatroItalianoLobos.Web.Models.Empleado;
using CineTeatroItalianoLobos.Web.Models.TipoDocumento;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CineTeatroItalianoLobos.Web.Controllers
{
    public class TipoDocumentoController : Controller
    {
        private readonly ITiposDocumentosServicio _servicio;
        private readonly IEmpleadosServicio _servicioEmpleados;
        private readonly int cantidadPorPaginas = 12;
        public TipoDocumentoController(ITiposDocumentosServicio servicio,
            IEmpleadosServicio servicioEmpleados)
        {
            _servicio = servicio;
            _servicioEmpleados = servicioEmpleados;
        }
        public ActionResult Index(int? page = null)
        {
            page = (page ?? 1);
            var lista = _servicio.GetLista();
            var listaVm = Mapeador.ConstruirListaTipoDocumentoVm(lista);
            foreach (var tipoDocumentoVm in listaVm)
            {
                tipoDocumentoVm.CantidadEmpleados = _servicioEmpleados.GetCantidad(e => e.TipoDocumentoId == tipoDocumentoVm.TipoDocumentoId);
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
        public ActionResult Create(TipoDocumentoEditVm tipoDocumentoEditVm)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoDocumentoEditVm);
            }
            var tipoDocumento = Mapeador.ContruirTipoDocumento(tipoDocumentoEditVm);
            try
            {
                if (_servicio.Existe(tipoDocumento))
                {
                    ModelState.AddModelError(string.Empty, "TipoDocumento existente");
                    return View(tipoDocumentoEditVm);
                }
                _servicio.Guardar(tipoDocumento);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(tipoDocumentoEditVm);
            }
        }


        [HttpGet]

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tipoDocumento = _servicio.GetTEntityPorId(id.Value);
            if (tipoDocumento == null)
            {
                return new HttpNotFoundResult("Codigo de TipoDocumento inexistente");
            }
            var tipoDocumentoEditVm = Mapeador.ConstruirTipoDocumentoEditVm(tipoDocumento);
            return View(tipoDocumentoEditVm);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoDocumentoEditVm tipoDocumentoEditVm)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoDocumentoEditVm);
            }
            var tipoDocumento = Mapeador.ContruirTipoDocumento(tipoDocumentoEditVm);
            try
            {
                if (_servicio.Existe(tipoDocumento))
                {
                    ModelState.AddModelError(string.Empty, "TipoDocumento existente");
                    return View(tipoDocumentoEditVm);
                }
                _servicio.Guardar(tipoDocumento);
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(tipoDocumentoEditVm);
            }
        }
        [HttpGet]

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tipoDocumento = _servicio.GetTEntityPorId(id.Value);
            if (tipoDocumento == null)
            {
                return new HttpNotFoundResult("Codigo de TipoDocumento inexistente");
            }
            var tipoDocumentoVm = Mapeador.ConstruirTipoDocumentoListVm(tipoDocumento);
            return View(tipoDocumentoVm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var tipoDocumento = _servicio.GetTEntityPorId(id);
            var tipoDocumentoVm = Mapeador.ConstruirTipoDocumentoListVm(tipoDocumento);
            if (_servicio.EstaRelacionado(tipoDocumento))
            {

                ModelState.AddModelError(string.Empty, "TipoDocumento relacionada");
                return View(tipoDocumentoVm);
            }
            try
            {
                _servicio.Borrar(id);
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(tipoDocumentoVm);
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tipoDocumento = _servicio.GetTEntityPorId(id.Value);
            if (tipoDocumento == null)
            {
                return HttpNotFound("Codigo de TipoDocumento Inexistente");
            }
            var tipoDocumentoDetailsVm = Mapeador.ConstruirTipoDocumentoDetailsVm(tipoDocumento);
            tipoDocumentoDetailsVm.CantidadEmpleados = _servicioEmpleados.GetCantidad(e => e.TipoDocumentoId == tipoDocumento.TipoDocumentoId);
            tipoDocumentoDetailsVm.Empleados = Mapeador.ConstruirListaEmpleadosVm(_servicioEmpleados.Find(e => e.TipoDocumentoId == tipoDocumento.TipoDocumentoId, null, null));
            return View(tipoDocumentoDetailsVm);
        }
        public ActionResult AddEmpleado(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var tipoDocumento = _servicio.GetTEntityPorId(id.Value);
            if (tipoDocumento == null)
            {
                return HttpNotFound("Código de tipo de documento inexistente!!!");
            }

            var empleadoEditVm = new EmpleadoEditVm()
            {
                TipoDocumentoId = tipoDocumento.TipoDocumentoId,
                TipoDocumento = Mapeador.ConstruirTipoDocumentoListVm(tipoDocumento)
            };
            return View(empleadoEditVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEmpleado(EmpleadoEditVm empleadoEditVm)
        {
            if (!ModelState.IsValid)
            {
                var tipoDocumento = Mapeador.ConstruirTipoDocumentoListVm(_servicio.GetTEntityPorId(empleadoEditVm.TipoDocumentoId));
                empleadoEditVm.TipoDocumento = tipoDocumento;
                return View(empleadoEditVm);
            }

            var empleado = Mapeador.ConstruirEmpleado(empleadoEditVm);
            try
            {
                if (_servicioEmpleados.Existe(empleado))
                {
                    var tipoDocumento = Mapeador.ConstruirTipoDocumentoListVm(_servicio.GetTEntityPorId(empleadoEditVm.TipoDocumentoId));
                    empleadoEditVm.TipoDocumento = tipoDocumento;

                    ModelState.AddModelError(string.Empty, "Empleado existente!!!");
                    return View(empleadoEditVm);
                }
                _servicioEmpleados.Guardar(empleado);
                return RedirectToAction($"Details/{empleado.TipoDocumentoId}");
            }
            catch (Exception e)
            {
                var tipoDocumento = Mapeador.ConstruirTipoDocumentoListVm(_servicio.GetTEntityPorId(empleadoEditVm.TipoDocumentoId));
                empleadoEditVm.TipoDocumento = tipoDocumento;
                ModelState.AddModelError(string.Empty, e.Message);
                return View(empleadoEditVm);
            }
        }
    }
}