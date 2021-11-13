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
            HasKey(vt => vt.VentaTicketId);
            Property(vt=>vt.TicketId).IsRequired();
            Property(vt => vt.VentaId).IsRequired();

        }
    }
}
