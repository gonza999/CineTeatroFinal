using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatroItalianoLobos.Data.EntityTypeConfigurations
{
    public class FormaVentaEntityTypeConfiguration:EntityTypeConfiguration<FormaVenta>
    {
        public FormaVentaEntityTypeConfiguration()
        {
            ToTable("FormasVentas");
            HasKey(fv=> fv.FormaVentaId);
            Property(fv => fv.Descripcion).HasColumnName("FormaVenta").IsRequired().HasMaxLength(50);
        }
    }
}
