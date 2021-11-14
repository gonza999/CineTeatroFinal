using CineTeatroItalianoLobos.Services.Facades;
using CineTeatroItalianoLobos.Web.Clases;
using CineTeatroItalianoLobos.Web.Models.FormaPago;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CineTeatroItalianoLobos.Web.Controllers
{
    public class FormaPagoController : Controller
    {
        private readonly IFormasPagosServicio _servicio;
        //private readonly ITicketsServicios _servicioTickets;
        private readonly int cantidadPorPaginas = 12;
        public FormaPagoController(IFormasPagosServicio servicio
            /*,ITicketsServicios servicioTickets*/)
        {
            _servicio = servicio;
            //_servicioTickets = servicioTickets;
        }
        public ActionResult Index(int? page = null)
        {
            page = (page ?? 1);
            var lista = _servicio.GetLista();
            var listaVm = Mapeador.ConstruirListaFormaPagoVm(lista);
            foreach (var formaPagoVm in listaVm)
            {
                formaPagoVm.CantidadTickets = 0;
                //formaPagoVm.CantidadTickets = _servicioTickets.GetCantidad(e => e.FormaPagoId == formaPagoVm.FormaPagoId);
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
        public ActionResult Create(FormaPagoEditVm formaPagoEditVm)
        {
            if (!ModelState.IsValid)
            {
                return View(formaPagoEditVm);
            }
            var formaPago = Mapeador.ContruirFormaPago(formaPagoEditVm);
            try
            {
                if (_servicio.Existe(formaPago))
                {
                    ModelState.AddModelError(string.Empty, "FormaPago existente");
                    return View(formaPagoEditVm);
                }
                _servicio.Guardar(formaPago);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(formaPagoEditVm);
            }
        }


        [HttpGet]

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var formaPago = _servicio.GetTEntityPorId(id.Value);
            if (formaPago == null)
            {
                return new HttpNotFoundResult("Codigo de FormaPago inexistente");
            }
            var formaPagoEditVm = Mapeador.ConstruirFormaPagoEditVm(formaPago);
            return View(formaPagoEditVm);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormaPagoEditVm formaPagoEditVm)
        {
            if (!ModelState.IsValid)
            {
                return View(formaPagoEditVm);
            }
            var formaPago = Mapeador.ContruirFormaPago(formaPagoEditVm);
            try
            {
                if (_servicio.Existe(formaPago))
                {
                    ModelState.AddModelError(string.Empty, "FormaPago existente");
                    return View(formaPagoEditVm);
                }
                _servicio.Guardar(formaPago);
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(formaPagoEditVm);
            }
        }
        [HttpGet]

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var formaPago = _servicio.GetTEntityPorId(id.Value);
            if (formaPago == null)
            {
                return new HttpNotFoundResult("Codigo de FormaPago inexistente");
            }
            var formaPagoVm = Mapeador.ConstruirFormaPagoListVm(formaPago);
            return View(formaPagoVm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var formaPago = _servicio.GetTEntityPorId(id);
            var formaPagoVm = Mapeador.ConstruirFormaPagoListVm(formaPago);
            if (_servicio.EstaRelacionado(formaPago))
            {

                ModelState.AddModelError(string.Empty, "FormaPago relacionada");
                return View(formaPagoVm);
            }
            try
            {
                _servicio.Borrar(id);
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(formaPagoVm);
            }
        }

        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var formaPago = _servicio.GetTEntityPorId(id.Value);
        //    if (formaPago == null)
        //    {
        //        return HttpNotFound("Codigo de FormaPago Inexistente");
        //    }
        //    var formaPagoDetailsVm = Mapeador.ConstruirFormaPagoDetailsVm(formaPago);
        //    formaPagoDetailsVm.CantidadTickets = _servicioTickets.GetCantidad(e => e.FormaPagoId == formaPago.FormaPagoId);
        //    //formaPagoDetailsVm.Tickets = Mapeador.ConstruirListaTicketsVm(_servicioTickets.Find(e => e.FormaPagoId == formaPago.FormaPagoId, null, null));
        //    return View(formaPagoDetailsVm);
        //}
    }
}