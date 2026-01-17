using DAL.EF.Models;
using DAL.EF.Models.DAL.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class SSMSContext : DbContext
    {
        public SSMSContext(DbContextOptions<SSMSContext> opt) : base(opt) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Payment> Payments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User -> Feedback: Restrict delete to avoid multiple cascade paths
            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.User)
                .WithMany()  // no navigation property needed
                .HasForeignKey(f => f.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            // Booking -> User: Restrict delete to avoid multiple cascade paths
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany()  // no navigation property needed
                .HasForeignKey(b => b.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            // Feedback <-> Booking 1:1: Keep cascade if desired
            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Booking)
                .WithOne(b => b.Feedback)
                .HasForeignKey<Feedback>(f => f.BookingID)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);

            // booking-payment one to one
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Payment)
                .WithOne(p => p.Booking)
                .HasForeignKey<Payment>(p => p.BookingID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
