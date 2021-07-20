using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CineTeatroItalianoLobos.Entities
{
    public class Ubicacion
    {
        public Ubicacion()
        {
            Localidades = new HashSet<Localidad>();
        }
        public int UbicacionId { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Localidad> Localidades { get; set; }
    }
}
