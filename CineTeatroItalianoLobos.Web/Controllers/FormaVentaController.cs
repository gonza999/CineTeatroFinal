using CineTeatroItalianoLobos.Services.Facades;
using CineTeatroItalianoLobos.Web.Clases;
using CineTeatroItalianoLobos.Web.Models.FormaVenta;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CineTeatroItalianoLobos.Web.Controllers
{
    public class FormaVentaController : Controller
    {
        private readonly IFormasVentasServicio _servicio;
        private readonly ITicketsServicio _servicioTickets;
        private readonly int cantidadPorPaginas = 12;
        public FormaVentaController(IFormasVentasServicio servicio
            , ITicketsServicio servicioTickets)
        {
            _servicio = servicio;
            _servicioTickets = servicioTickets;
        }
        public ActionResult Index(int? page = null)
        {
            page = (page ?? 1);
            var lista = _servicio.GetLista();
            var listaVm = Mapeador.ConstruirListaFormaVentaVm(lista);
            foreach (var formaVentaVm in listaVm)
            {
                formaVentaVm.CantidadTickets = 0;
                formaVentaVm.CantidadTickets = _servicioTickets.GetCantidad(e => e.FormaVentaId == formaVentaVm.FormaVentaId);
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
        public ActionResult Create(FormaVentaEditVm formaVentaEditVm)
        {
            if (!ModelState.IsValid)
            {
                return View(formaVentaEditVm);
            }
            var formaVenta = Mapeador.ContruirFormaVenta(formaVentaEditVm);
            try
            {
                if (_servicio.Existe(formaVenta))
                {
                    ModelState.AddModelError(string.Empty, "FormaVenta existente");
                    return View(formaVentaEditVm);
                }
                _servicio.Guardar(formaVenta);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(formaVentaEditVm);
            }
        }


        [HttpGet]

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var formaVenta = _servicio.GetTEntityPorId(id.Value);
            if (formaVenta == null)
            {
                return new HttpNotFoundResult("Codigo de FormaVenta inexistente");
            }
            var formaVentaEditVm = Mapeador.ConstruirFormaVentaEditVm(formaVenta);
            return View(formaVentaEditVm);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormaVentaEditVm formaVentaEditVm)
        {
            if (!ModelState.IsValid)
            {
                return View(formaVentaEditVm);
            }
            var formaVenta = Mapeador.ContruirFormaVenta(formaVentaEditVm);
            try
            {
                if (_servicio.Existe(formaVenta))
                {
                    ModelState.AddModelError(string.Empty, "FormaVenta existente");
                    return View(formaVentaEditVm);
                }
                _servicio.Guardar(formaVenta);
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(formaVentaEditVm);
            }
        }
        [HttpGet]

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var formaVenta = _servicio.GetTEntityPorId(id.Value);
            if (formaVenta == null)
            {
                return new HttpNotFoundResult("Codigo de FormaVenta inexistente");
            }
            var formaVentaVm = Mapeador.ConstruirFormaVentaListVm(formaVenta);
            return View(formaVentaVm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var formaVenta = _servicio.GetTEntityPorId(id);
            var formaVentaVm = Mapeador.ConstruirFormaVentaListVm(formaVenta);
            if (_servicio.EstaRelacionado(formaVenta))
            {

                ModelState.AddModelError(string.Empty, "FormaVenta relacionada");
                return View(formaVentaVm);
            }
            try
            {
                _servicio.Borrar(id);
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(formaVentaVm);
            }
        }

        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var formaVenta = _servicio.GetTEntityPorId(id.Value);
        //    if (formaVenta == null)
        //    {
        //        return HttpNotFound("Codigo de FormaVenta Inexistente");
        //    }
        //    var formaVentaDetailsVm = Mapeador.ConstruirFormaVentaDetailsVm(formaVenta);
        //    formaVentaDetailsVm.CantidadTickets = _servicioTickets.GetCantidad(e => e.FormaVentaId == formaVenta.FormaVentaId);
        //    //formaVentaDetailsVm.Tickets = Mapeador.ConstruirListaTicketsVm(_servicioTickets.Find(e => e.FormaVentaId == formaVenta.FormaVentaId, null, null));
        //    return View(formaVentaDetailsVm);
        //}

    }
}