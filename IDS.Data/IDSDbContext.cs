using IDS.Core.Models;
using IDS.Core.Models.Auth;
using IDS.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IDS.Data
{
    public class IDSDbContext : IdentityDbContext<Core.Models.Auth.CustomUser, CustomRole, Guid>
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Reservation> Reservations  { get; set; }

        public DbSet <Role> Roles { get; set; }
        public DbSet <Room> Rooms { get; set; }
        public DbSet <Core.Models.CustomUser> Users { get; set; } 
        public IDSDbContext(DbContextOptions<IDSDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder); 
            builder
                .ApplyConfiguration(new CompanyConfiguration());

            builder
                .ApplyConfiguration(new ReservationConfiguration());

            builder 
                .ApplyConfiguration(new RoleConfiguration());   

            builder
                .ApplyConfiguration(new RoomConfiguration());

            builder
               .ApplyConfiguration(new UserConfiguration());


        }
    }
}
