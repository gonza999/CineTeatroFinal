using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineTeatroItalianoLobos.Web.Models.TipoEvento
{
    public class TipoEventoDetail
    {
        public int TipoEventoId { get; set; }
        public string Descripcion { get; set; }
        public List<Evento> Productos { get; set; }
    }
}