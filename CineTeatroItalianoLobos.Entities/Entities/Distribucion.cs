
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CineTeatroItalianoLobos.Entities
{
    public  class Distribucion
    {
        public Distribucion()
        {
            DistribucionesLocalidades = new HashSet<DistribucionLocalidad>();
            Eventos = new HashSet<Evento>();
        }
        public int DistribucionId { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<DistribucionLocalidad> DistribucionesLocalidades { get; set; }
        public virtual ICollection<Evento> Eventos { get; set; }
    }
}
