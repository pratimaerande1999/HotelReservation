using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservation.Models;

namespace HotelReservation.Models
{
    public class guestDbContext : DbContext
    {
        public DbSet<guest> guest { get; set; }
        public DbSet<Occupied_room> occupied_Rooms { get; set; }
        


        public guestDbContext(DbContextOptions<guestDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<guest>().ToTable("guest");
            modelBuilder.Entity<Occupied_room>().ToTable("Occupied_room");
            modelBuilder.Entity<Admitance>().ToTable("Admitance");

        }
        public DbSet<HotelReservation.Models.Admitance> Admitance { get; set; }
    }
}




