using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineTeatroItalianoLobos.Entities
{
    public  class Ticket : ICloneable
    {
        public Ticket()
        {
            Ventas = new HashSet<Venta>();
        }
        public int TicketId { get; set; }
        public int HorarioId { get; set; }
        public decimal Importe { get; set; }
        public int LocalidadId { get; set; }
        public DateTime FechaVenta { get; set; }
        public int FormaPagoId { get; set; }
        public int FormaVentaId { get; set; }
        public bool Anulada { get; set; }
        public virtual FormaPago FormaPago { get; set; }
        public virtual FormaVenta FormaVenta { get; set; }
        public virtual Horario Horario { get; set; }
        public virtual Localidad Localidad { get; set; }
        public virtual ICollection<Venta> Ventas { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
