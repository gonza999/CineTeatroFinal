using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineTeatroItalianoLobos.Web.Models.FormaPago
{
    public class FormaPagoListVm
    {
        public int FormaPagoId { get; set; }
        public string Descripcion { get; set; }
        public int CantidadTickets { get; set; }
    }
}