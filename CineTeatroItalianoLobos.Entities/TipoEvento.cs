using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineTeatroItalianoLobos.Entities
{
    public class TipoEvento
    {
        public TipoEvento()
        {
            Eventos = new HashSet<Evento>();
        }
        public int TipoEventoId { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Evento> Eventos { get; set; }
    }
}
