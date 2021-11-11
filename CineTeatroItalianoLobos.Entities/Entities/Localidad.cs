
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineTeatroItalianoLobos.Entities
{
    public class Localidad : ICloneable
    {
        public Localidad()
        {
            DistribucionesLocalidades = new HashSet<DistribucionLocalidad>();
            Tickets = new HashSet<Ticket>();
        }
        public int LocalidadId { get; set; }
        public int PlantaId { get; set; }
        public int Numero { get; set; }
        public int UbicacionId { get; set; }
        public int Fila { get; set; }
        public virtual ICollection<DistribucionLocalidad> DistribucionesLocalidades { get; set; }
        public virtual Planta Planta { get; set; }
        public virtual Ubicacion Ubicacion { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
