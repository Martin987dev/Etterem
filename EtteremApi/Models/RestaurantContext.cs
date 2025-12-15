using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EtteremApi.Models;

public partial class RestaurantContext : DbContext
{
    public RestaurantContext()
    {
    }

    public RestaurantContext(DbContextOptions<RestaurantContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Kapcsolo> Kapcsolos { get; set; }

    public virtual DbSet<Rendeles> Rendeles { get; set; }

    public virtual DbSet<Termekek> Termekeks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kapcsolo>(entity =>
        {
            entity.HasKey(e => e.KapcsoloId).HasName("PRIMARY");

            entity.ToTable("kapcsolo");

            entity.HasIndex(e => e.RendelesId, "RendelesId");

            entity.HasIndex(e => e.TermekekId, "TermekekId");

            entity.Property(e => e.KapcsoloId).HasColumnType("int(11)");
            entity.Property(e => e.RendelesId).HasColumnType("int(11)");
            entity.Property(e => e.TermekekId).HasColumnType("int(11)");

            entity.HasOne(d => d.Rendeles).WithMany(p => p.Kapcsolos)
                .HasForeignKey(d => d.RendelesId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("kapcsolo_ibfk_1");

            entity.HasOne(d => d.Termekek).WithMany(p => p.Kapcsolos)
                .HasForeignKey(d => d.TermekekId)
                .HasConstraintName("kapcsolo_ibfk_2");
        });

        modelBuilder.Entity<Rendeles>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("rendeles");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Asztalszam)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)");
            entity.Property(e => e.Fizetesimod)
                .HasMaxLength(50)
                .HasDefaultValueSql("'NULL'");
        });

        modelBuilder.Entity<Termekek>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("termekek");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Arak)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(25)");
            entity.Property(e => e.Etel)
                .HasMaxLength(255)
                .HasDefaultValueSql("'NULL'");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
