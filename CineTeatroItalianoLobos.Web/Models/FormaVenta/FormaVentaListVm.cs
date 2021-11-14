using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineTeatroItalianoLobos.Web.Models.FormaVenta
{
    public class FormaVentaListVm
    {
        public int FormaVentaId { get; set; }
        public string Descripcion { get; set; }
        public int CantidadTickets { get; set; }

    }
}