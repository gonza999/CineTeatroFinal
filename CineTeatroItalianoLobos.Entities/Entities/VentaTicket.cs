using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatroItalianoLobos.Entities
{
    public class VentaTicket : ICloneable
    {
        public int VentaTicketId { get; set; }
        public int TicketId { get; set; }
        public int VentaId { get; set; }
        public virtual Ticket Ticket { get; set; }
        public virtual Venta Venta { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
