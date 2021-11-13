
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineTeatroItalianoLobos.Entities
{
    public class Empleado:ICloneable
    {
        public Empleado()
        {
            Ventas = new HashSet<Venta>();
        }
        public int EmpleadoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int TipoDocumentoId { get; set; }
        public string NroDocumento { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoMovil { get; set; }
        public string Mail { get; set; }
        public virtual TipoDocumento TipoDocumento { get; set; }
        public virtual ICollection<Venta> Ventas { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
