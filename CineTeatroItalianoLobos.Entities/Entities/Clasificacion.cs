using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CineTeatroItalianoLobos.Entities
{
    public  class Clasificacion:ICloneable
    {
        public Clasificacion()
        {
            Eventos = new HashSet<Evento>();
        }
        public int ClasificacionId { get; set; }

        public string Descripcion { get; set; }

        public virtual ICollection<Evento> Eventos { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
