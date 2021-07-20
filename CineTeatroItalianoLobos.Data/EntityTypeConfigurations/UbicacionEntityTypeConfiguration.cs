using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatroItalianoLobos.Data.EntityTypeConfigurations
{
   public class UbicacionEntityTypeConfiguration:EntityTypeConfiguration<Ubicacion>
    {
        public UbicacionEntityTypeConfiguration()
        {
            ToTable("Ubicaciones");
            HasKey(u=>u.UbicacionId);
            Property(u=>u.Descripcion).HasColumnName("Ubicacion").IsRequired().HasMaxLength(50);
        }
    }
}
