
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineTeatroItalianoLobos.Entities
{
    public class FormaPago
    {
        public FormaPago()
        {
            Tickets = new HashSet<Ticket>();
        }
        public int FormaPagoId { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
