using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineTeatroItalianoLobos.Web.Models.Ticket
{
    public class TicketListVm
    {
        public int TicketId { get; set; }
        public string Evento { get; set; }
        public decimal Importe { get; set; }
        public string FormaPago { get; set; }
        public string FormaVenta { get; set; }
    }
}