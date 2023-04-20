using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EUCTest.Models;

public partial class EucDatabaseContext : DbContext
{
    public EucDatabaseContext()
    {
    }

    public EucDatabaseContext(DbContextOptions<EucDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Sex> SexList { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Country__3214EC077432AD66");

            entity.ToTable("Country");

            entity.Property(e => e.Iso)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Iso3)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Nicename)
                .HasMaxLength(80)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.ToTable("Person");

            entity.Property(e => e.Birthdate).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsFixedLength();
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.IdentityNumber).HasMaxLength(20);
            entity.Property(e => e.LastName).HasMaxLength(100);

            //entity.HasOne(d => d.Country).WithMany(p => p.People)
            //    .HasForeignKey(d => d.CountryId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_Person_Country");

            //entity.HasOne(d => d.Sex).WithMany(p => p.People)
            //    .HasForeignKey(d => d.SexId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_Person_Sex");
        });

        modelBuilder.Entity<Sex>(entity =>
        {
            entity.ToTable("Sex");

            entity.Property(e => e.Value).HasMaxLength(10);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
