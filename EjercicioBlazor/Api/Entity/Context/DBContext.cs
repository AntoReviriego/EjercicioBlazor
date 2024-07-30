using System;
using System.Collections.Generic;
using Api.Entity;
using Microsoft.EntityFrameworkCore;

namespace Api.Entity.Context;

public partial class DBContext : DbContext
{
    public DBContext()
    {
    }

    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.InsertDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.ToTable("Marca");

            entity.Property(e => e.Descripcion).HasMaxLength(350);
            entity.Property(e => e.InsertDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.ToTable("Producto");

            entity.Property(e => e.Code).IsUnicode(false);
            entity.Property(e => e.Descripcion).HasMaxLength(350);
            entity.Property(e => e.IdCategoria).HasColumnName("Id_categoria");
            entity.Property(e => e.IdMarca).HasColumnName("Id_marca");
            entity.Property(e => e.InsertDate).HasColumnType("datetime");
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Producto_Categoria");

            entity.HasOne(d => d.IdMarcaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdMarca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Producto_Marca");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
