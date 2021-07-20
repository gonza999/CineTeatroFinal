using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatroItalianoLobos.Data.EntityTypeConfigurations
{
    public class VentaEntityTypeConfiguration:EntityTypeConfiguration<Venta>
    {
        public VentaEntityTypeConfiguration()
        {
            ToTable("Ventas");
            HasKey(v=>v.VentaId);
            Property(v=>v.Total).HasColumnType("numeric");
        }
    }
}
