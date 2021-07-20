using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineTeatroItalianoLobos.Entities
{
    public class DistribucionLocalidad
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DistribucionId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LocalidadId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Precio { get; set; }

        public virtual Distribucion Distribucion { get; set; }

        public virtual Localidad Localidad { get; set; }
    }
}
