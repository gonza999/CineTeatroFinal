
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineTeatroItalianoLobos.Entities
{
    public class Planta
    {
        public Planta()
        {
            Localidades = new HashSet<Localidad>();
        }
        public int PlantaId { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Localidad> Localidades { get; set; }
    }
}
