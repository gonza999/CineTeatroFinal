using CineTeatroItalianoLobos.Web.Models.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineTeatroItalianoLobos.Web.Models.FormaPago
{
    public class FormaPagoDetail
    {
        public int FormaPagoId { get; set; }
        public string Descripcion { get; set; }
        public int CantidadTickets { get; set; }
        public List<TicketListVm> Tickets { get; set; }

    }
}