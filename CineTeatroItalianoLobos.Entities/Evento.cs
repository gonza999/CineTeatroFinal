using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineTeatroItalianoLobos.Entities
{
    public class Evento
    {
        public Evento()
        {
            Horarios = new HashSet<Horario>();
        }
        public int EventoId { get; set; }
        public int TipoEventoId { get; set; }
        public int ClasificacionId { get; set; }
        public string NombreEvento { get; set; }
        public DateTime FechaEvento { get; set; }
        public string Descripcion { get; set; }
        public bool Suspendido { get; set; }
        public int DistribucionId { get; set; }
        public virtual Clasificacion Clasificacion { get; set; }
        public virtual Distribucion Distribucion { get; set; }
        public virtual TipoEvento TipoEvento { get; set; }
        public virtual ICollection<Horario> Horarios { get; set; }
    }
}
