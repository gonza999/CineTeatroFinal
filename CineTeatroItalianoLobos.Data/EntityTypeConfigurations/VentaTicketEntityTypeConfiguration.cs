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
    public class VentaTicketEntityTypeConfiguration:EntityTypeConfiguration<VentaTicket>
    {
        public VentaTicketEntityTypeConfiguration()
        {
            ToTable("VentasTicket");
            HasKey(vt => new { vt.VentaId, vt.TicketId });
            Property(vt=>vt.TicketId).HasColumnOrder(0)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(vt => vt.VentaId).HasColumnOrder(1)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
