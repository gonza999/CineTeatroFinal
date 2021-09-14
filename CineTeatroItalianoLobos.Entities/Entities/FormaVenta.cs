
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CineTeatroItalianoLobos.Entities
{
    public class FormaVenta: ICloneable
    {
        public FormaVenta()
        {
            Tickets = new HashSet<Ticket>();
        }
        public int FormaVentaId { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
