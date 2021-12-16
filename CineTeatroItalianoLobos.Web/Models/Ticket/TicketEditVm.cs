using CineTeatroItalianoLobos.Web.Models.FormaPago;
using CineTeatroItalianoLobos.Web.Models.FormaVenta;
using CineTeatroItalianoLobos.Web.Models.Horario;
using CineTeatroItalianoLobos.Web.Models.Localidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineTeatroItalianoLobos.Web.Models.Ticket
{
    public class TicketEditVm
    {
        public int TicketId { get; set; }
        public int HorarioId { get; set; }
        public HorarioListVm Horario { get; set; }
        public List<HorarioListVm> Horarios { get; set; }
        public decimal Importe { get; set; }
        public int LocalidadId { get; set; }
        public LocalidadListVm Localidad { get; set; }
        public List<LocalidadListVm> Localidades { get; set; }
        public DateTime FechaVenta { get; set; }
        public int FormaPagoId { get; set; }
        public FormaPagoListVm FormaPago { get; set; }
        public List<FormaPagoListVm> FormasPagos { get; set; }
        public int FormaVentaId { get; set; }
        public FormaVentaListVm FormaVenta { get; set; }
        public List<FormaVentaListVm> FormasVenta { get; set; }
        public bool Anulada { get; set; }
    }
}