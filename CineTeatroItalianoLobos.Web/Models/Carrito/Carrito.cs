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
        public int EventoId { get; set; }
        public EventoListVm Evento { get; set; }
        public List<EventoListVm> Eventos { get; set; }
        [Display(Name = "Horario")]

        public int HorarioId { get; set; }
        public HorarioListVm Horario { get; set; }
        public List<HorarioListVm> Horarios { get; set; }
        [Display(Name = "Forma de Venta")]

        public int FormaVentaId { get; set; }
        public FormaVentaListVm FormaVenta { get; set; }
        public List<FormaVentaListVm> FormasVentas { get; set; }
        [Display(Name = "Forma de Pago")]

        public int FormaPagoId { get; set; }
        public FormaPagoListVm FormaPago { get; set; }
        public List<FormaPagoListVm> FormasPagos { get; set; }
        [Display(Name = "Localidad")]

        public int LocalidadId { get; set; }
        public LocalidadListVm Localidad { get; set; }
        public List<LocalidadListVm> Localidades { get; set; }
    }
}