
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineTeatroItalianoLobos.Entities
{
    public class FormaPago: ICloneable
    {
        public FormaPago()
        {
            Tickets = new HashSet<Ticket>();
        }
        public int FormaPagoId { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
