using CineTeatroItalianoLobos.Entities;
using CineTeatroItalianoLobos.Services.Facades;
using CineTeatroItalianoLobos.Web.Clases;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CineTeatroItalianoLobos.Web.Controllers
{
    public class VentaController : Controller
    {
        private readonly IVentasServicio _servicio;
        private readonly IEmpleadosServicio _servicioEmpleados;
        private readonly int cantidadPorPaginas = 12;
        public VentaController(IVentasServicio servicio,
            IEmpleadosServicio servicioEmpleados)
        {
            _servicio = servicio;
            _servicioEmpleados = servicioEmpleados;
        }
        public ActionResult Index(int? empleadoSeleccionadoId = null, int? page = null)
        {
            page = (page ?? 1);
            if (empleadoSeleccionadoId != null)
            {
                Session["empleadoSeleccionadoId"] = empleadoSeleccionadoId;
            }
            else
            {
                if (Session["empleadoSeleccionadoId"] != null)
                {
                    empleadoSeleccionadoId = (int)Session["empleadoSeleccionadoId"];
                }
            }
            List<Venta> lista;
            if (empleadoSeleccionadoId != null)
            {
                if (empleadoSeleccionadoId.Value > 0)
                {
                    var e = _servicioEmpleados.GetTEntityPorId(empleadoSeleccionadoId.Value);
                    lista = _servicio.GetLista(e);
                }
                else
                {
                    lista = _servicio.GetLista();
                }
            }
            else
            {
                lista = _servicio.GetLista();
            }
            var listaVm = Mapeador.ConstuirListaVentaVm(lista);
            var listaEmpleados = _servicioEmpleados.GetLista();
            listaEmpleados.Insert(0, new Empleado() { EmpleadoId = 0, Nombre = "[Seleccione un Empleado]" });
            listaEmpleados.Insert(1, new Empleado() { EmpleadoId = -1, Nombre = "[Ver Todos]" });

            ViewBag.Empleados = new SelectList(listaEmpleados, "EmpleadoId", "Nombre", empleadoSeleccionadoId);


            return View(listaVm.ToPagedList((int)page, cantidadPorPaginas));
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}