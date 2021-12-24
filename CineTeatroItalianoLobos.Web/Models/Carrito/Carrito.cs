using CineTeatroItalianoLobos.Web.Models.Empleado;
using CineTeatroItalianoLobos.Web.Models.Evento;
using CineTeatroItalianoLobos.Web.Models.FormaPago;
using CineTeatroItalianoLobos.Web.Models.FormaVenta;
using CineTeatroItalianoLobos.Web.Models.Horario;
using CineTeatroItalianoLobos.Web.Models.Localidad;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CineTeatroItalianoLobos.Web.Models.Carrito
{
    public class Carrito
    {
        [Display(Name ="Evento")]
        [Required(ErrorMessage = "El campo {0} es requerido")]

        public int EventoId { get; set; }
        public EventoListVm Evento { get; set; }
        public List<EventoListVm> Eventos { get; set; }
        [Display(Name = "Horario")]
        [Required(ErrorMessage = "El campo {0} es requerido")]

        public int HorarioId { get; set; }
        public HorarioListVm Horario { get; set; }
        public List<HorarioListVm> Horarios { get; set; }
        [Display(Name = "Forma de Venta")]
        [Required(ErrorMessage = "El campo {0} es requerido")]

        public int FormaVentaId { get; set; }
        public FormaVentaListVm FormaVenta { get; set; }
        public List<FormaVentaListVm> FormasVentas { get; set; }
        [Display(Name = "Forma de Pago")]
        [Required(ErrorMessage = "El campo {0} es requerido")]

        public int FormaPagoId { get; set; }
        public FormaPagoListVm FormaPago { get; set; }
        public List<FormaPagoListVm> FormasPagos { get; set; }
        [Display(Name = "Localidad")]
        [Required(ErrorMessage = "El campo {0} es requerido")]

        public int LocalidadId { get; set; }
        public LocalidadListVm Localidad { get; set; }
        public List<LocalidadListVm> Localidades { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(0, int.MaxValue)]
        public decimal Importe { get; set; }

        [Display(Name = "Empleado")]
        [Required(ErrorMessage = "El campo {0} es requerido")]

        public int EmpleadoId { get; set; }
        public EmpleadoListVm Empleado { get; set; }
        public List<EmpleadoListVm> Empleados { get; set; }
    }
}