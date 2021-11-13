using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineTeatroItalianoLobos.Entities
{
    public class DistribucionLocalidad:ICloneable
    {
        public int DistribucionLocalidadId { get; set; }
        public int DistribucionId { get; set; }
        public int LocalidadId { get; set; }
        public decimal Precio { get; set; }
        public virtual Distribucion Distribucion { get; set; }
        public virtual Localidad Localidad { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
