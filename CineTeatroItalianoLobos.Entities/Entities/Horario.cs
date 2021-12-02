using System;
using System.Collections.Generic;

namespace CineTeatroItalianoLobos.Entities
{
    public class Horario : ICloneable
    {
        public Horario()
        {
            Tickets = new HashSet<Ticket>();
            SetearFechaYHora();
        }
        public int HorarioId { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public int EventoId { get; set; }
        public virtual Evento Evento { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }

        public string FechaYHora { get; set; }

        public void SetearFechaYHora()
        {
            string minutos = "";
            string hora = "";
            if (Hora.TimeOfDay.Minutes < 10)
            {
                minutos = "0" + Hora.TimeOfDay.Minutes;
            }
            else
            {
                minutos = Hora.TimeOfDay.Minutes.ToString();
            }
            if (Hora.TimeOfDay.Hours < 10)
            {
                hora = "0" + Hora.TimeOfDay.Hours;
            }
            else
            {
                hora = Hora.TimeOfDay.Hours.ToString();
            }
            FechaYHora = Fecha.Year + "/" +
Fecha.Month + "/" +
Fecha.Day + " " + hora + ":" + minutos;
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
