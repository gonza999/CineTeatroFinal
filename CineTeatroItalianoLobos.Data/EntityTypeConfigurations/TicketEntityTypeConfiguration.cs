using CineTeatroItalianoLobos.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTeatroItalianoLobos.Data.EntityTypeConfigurations
{
    public class TicketEntityTypeConfiguration:EntityTypeConfiguration<Ticket>
    {
        public TicketEntityTypeConfiguration()
        {
            ToTable("Tickets");
            HasKey(t=>t.TicketId);
            Property(t=>t.Importe).HasColumnType("numeric");
        }
    }
}
