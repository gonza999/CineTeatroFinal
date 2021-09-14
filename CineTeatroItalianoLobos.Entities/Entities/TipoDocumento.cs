
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineTeatroItalianoLobos.Entities
{
    public class TipoDocumento : ICloneable
    {
        public TipoDocumento()
        {
            Empleados = new HashSet<Empleado>();
        }
        public int TipoDocumentoId { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Empleado> Empleados { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
