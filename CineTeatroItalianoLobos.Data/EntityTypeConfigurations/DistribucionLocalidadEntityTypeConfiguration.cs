using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatroItalianoLobos.Data.EntityTypeConfigurations
{
    public class DistribucionLocalidadEntityTypeConfiguration:EntityTypeConfiguration<DistribucionLocalidad>
    {
        public DistribucionLocalidadEntityTypeConfiguration()
        {
            ToTable("DistribucionesLocalidades");
            HasKey(dl =>dl.DistribucionLocalidadId);
            Property(dl => dl.Precio).HasColumnName("Precio").HasColumnType("numeric");
            Property(dl => dl.DistribucionId).IsRequired();
            Property(dl => dl.LocalidadId).IsRequired();
        }
    }
}
