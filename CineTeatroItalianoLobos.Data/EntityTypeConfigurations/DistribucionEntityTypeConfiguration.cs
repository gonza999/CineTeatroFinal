using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatroItalianoLobos.Data.EntityTypeConfigurations
{
    public class DistribucionEntityTypeConfiguration:EntityTypeConfiguration<Distribucion>
    {
        public DistribucionEntityTypeConfiguration()
        {
            ToTable("Distribuciones");
            HasKey(d=>d.DistribucionId);
            Property(d => d.Descripcion).HasColumnName("Distribucion").IsRequired().HasMaxLength(50);

        }
    }
}
