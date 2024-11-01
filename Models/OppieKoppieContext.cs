using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace oppiekoppie.Models;

public partial class OppieKoppieContext : DbContext
{
    public OppieKoppieContext()
    {
    }

    public OppieKoppieContext(DbContextOptions<OppieKoppieContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<GuestClient> GuestClients { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;user id=root;password=Poppup@123;database=OppieKoppie", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.36-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PRIMARY");

            entity.ToTable("Address");

            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.Street).HasMaxLength(50);
            entity.Property(e => e.Suburb).HasMaxLength(50);
            entity.Property(e => e.TownCity).HasMaxLength(50);
        });

        modelBuilder.Entity<GuestClient>(entity =>
        {
            entity.HasKey(e => e.GuestClientId).HasName("PRIMARY");

            entity.ToTable("GuestClient");

            entity.Property(e => e.Firstname).HasMaxLength(50);
            entity.Property(e => e.Lastname).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(50);
            entity.Property(e => e.TownCity).HasMaxLength(50);
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PRIMARY");

            entity.ToTable("Payment");

            entity.Property(e => e.Balance).HasPrecision(60, 2);
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Owed).HasPrecision(60, 2);
            entity.Property(e => e.Paid).HasPrecision(60, 2);
            entity.Property(e => e.PayDate).HasColumnType("datetime");
            entity.Property(e => e.PayType).HasMaxLength(50);
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PRIMARY");

            entity.ToTable("Room");

            entity.Property(e => e.RoomDetail).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
