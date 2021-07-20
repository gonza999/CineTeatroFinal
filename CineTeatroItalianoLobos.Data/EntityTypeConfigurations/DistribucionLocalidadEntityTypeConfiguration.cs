using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;
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
            HasKey(dl => new { dl.DistribucionId, dl.LocalidadId });
            
        }
    }
}
