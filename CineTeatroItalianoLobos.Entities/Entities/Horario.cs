using System;
using System.Collections.Generic;

namespace CineTeatroItalianoLobos.Entities
{
    public class Horario
    {
        public Horario()
        {
            Tickets = new HashSet<Ticket>();
        }
        public int HorarioId { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public int EventoId { get; set; }
        public virtual Evento Evento { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
