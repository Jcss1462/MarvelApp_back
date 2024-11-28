using System;
using System.Collections.Generic;
using MarvelApp_back.Models;
using Microsoft.EntityFrameworkCore;

namespace MarvelApp_back.Contexts;

public partial class MarvelDbContext : DbContext
{
    public MarvelDbContext()
    {
    }

    public MarvelDbContext(DbContextOptions<MarvelDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ComicFavorito> ComicFavoritos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ComicFavorito>(entity =>
        {
            entity.HasKey(e => new { e.IdUsuario, e.IdComic }).HasName("PK__ComicFav__F6001BD5370CD98A");

            entity.ToTable("ComicFavorito");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.ComicFavoritos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ComicFavo__IdUsu__3B75D760");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF9786A5B6E5");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Correo, "UQ__Usuario__60695A191664CF22").IsUnique();

            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Uid)
                .HasMaxLength(100)
                .HasColumnName("UID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
