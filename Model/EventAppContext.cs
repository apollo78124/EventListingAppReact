using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Configuration;

namespace EventReactApp.Model
{

    public partial class EventAppContext : DbContext
    {
        public EventAppContext(DbContextOptions<EventAppContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Events> Events { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Server=DESKTOP9DKFFR;Database=ECubed_Net_React_Demo;Trusted_Connection=True;MultipleActiveResultSets=true", providerOptions => providerOptions.CommandTimeout(60))
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }
        }

   //    protected override void OnModelCreating(ModelBuilder modelBuilder)
   //    {
   //        modelBuilder.Entity<Categories>(entity =>
   //        {
   //            entity.Property(e => e.CategoryName).IsUnicode(false);
   //        });
   //
   //        modelBuilder.Entity<Events>(entity =>
   //        {
   //            entity.Property(e => e.EventKeyword).IsUnicode(false);
   //
   //            entity.Property(e => e.EventName).IsUnicode(false);
   //
   //            entity.Property(e => e.EventSummary).IsUnicode(false);
   //
   //            entity.HasOne(d => d.Category)
   //                .WithMany(p => p.Events)
   //                .HasForeignKey(d => d.CategoryId)
   //                .OnDelete(DeleteBehavior.ClientSetNull)
   //                .HasConstraintName("FK_Events_Categories");
   //        });
   //
   //        OnModelCreatingPartial(modelBuilder);
   //    }
   //
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
