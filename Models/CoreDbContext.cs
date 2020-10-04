using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AAMBFS.Models
{
    public partial class CoreDbContext : DbContext
    {
        public CoreDbContext()
        {
        }

        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Occupation> Occupation { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderLine> OrderLine { get; set; }
        public virtual DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasIndex(e => e.City)
                    .HasName("Client_city");

                entity.HasIndex(e => e.DateOfBirth)
                    .HasName("Client_dateofbirth");

                entity.HasIndex(e => e.FirstName)
                    .HasName("Client_firstName");

                entity.HasIndex(e => e.LastName)
                    .HasName("Client_lastName");

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.MiddleName).IsUnicode(false);

                entity.Property(e => e.Notes).IsUnicode(false);

                entity.Property(e => e.Street1).IsUnicode(false);

                entity.Property(e => e.Street2).IsUnicode(false);

                entity.Property(e => e.TelephoneNumber).IsUnicode(false);

                entity.Property(e => e.Xcode)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ZipCode).IsUnicode(false);

                entity.HasOne(d => d.Occupation)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.OccupationId)
                    .HasConstraintName("FK_Client_Occupation");
            });

            modelBuilder.Entity<Occupation>(entity =>
            {
                entity.Property(e => e.OccupationName).IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.Property(e => e.OrderStatus)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("fk_Order_ClientId");
            });

            modelBuilder.Entity<OrderLine>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.LineNumber })
                    .HasName("pk_OrderId_LineNumber");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderLine)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_OrderLine_OrderId");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderLine)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_OrderLine_ProductId");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductName).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
