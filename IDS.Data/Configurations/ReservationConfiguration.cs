using IDS.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDS.Data.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.RoomId)
                .IsRequired()
                .HasMaxLength(50);

            /*builder
                .HasOne(m => m.Attendees)
                .WithMany(a => a.Attendees)
                .HasForeignKey(m => m.RoomId);
            */
            builder
                .ToTable("Reservations");
        }

      
    }
}
