using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CineTeatroItalianoLobos.Web.Models.Venta
{
    public class VentaListVm
    {
        public int VentaId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public bool Estado { get; set; }
        public string Empleado { get; set; }
        [Display(Name ="Tickets")]
        public int CantidadTickets { get; set; }
    }
}