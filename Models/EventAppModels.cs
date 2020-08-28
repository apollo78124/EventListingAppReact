namespace EventReactApp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EventAppModels : DbContext
    {
        public EventAppModels()
            : base("name=EventAppModels")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Events)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.EventName)
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.EventKeyword)
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.EventSummary)
                .IsUnicode(false);
        }
    }
}
