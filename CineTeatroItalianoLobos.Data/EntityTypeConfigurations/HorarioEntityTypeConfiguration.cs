using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatroItalianoLobos.Data.EntityTypeConfigurations
{
    public class HorarioEntityTypeConfiguration:EntityTypeConfiguration<Horario>
    {
        public HorarioEntityTypeConfiguration()
        {
            ToTable("Horarios");
            HasKey(h=>h.HorarioId);
        }
    }
}
