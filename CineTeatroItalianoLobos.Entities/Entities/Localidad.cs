
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CineTeatroItalianoLobos.Entities
{
    public class Localidad
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
    }
}
