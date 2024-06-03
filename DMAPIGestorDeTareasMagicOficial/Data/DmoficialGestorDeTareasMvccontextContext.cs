using System;
using System.Collections.Generic;
using DMAPIGestorDeTareasMagicOficial.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DMAPIGestorDeTareasMagicOficial.Data;

public partial class DmoficialGestorDeTareasMvccontextContext : DbContext
{
    public DmoficialGestorDeTareasMvccontextContext()
    {
    }

    public DmoficialGestorDeTareasMvccontextContext(DbContextOptions<DmoficialGestorDeTareasMvccontextContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DMCategoria> DMCategoria { get; set; }

    public virtual DbSet<DMPrioridad> DMPrioridades { get; set; }

    public virtual DbSet<DMTarea> DMTareas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DMOficialGestorDeTareasMVCContext;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DMCategoria>(entity =>
        {
            entity.HasKey(e => e.DMCategoriaID);

            entity.ToTable("DMCategoria");

            entity.Property(e => e.DMCategoriaID).HasColumnName("DMCategoriaID");
            entity.Property(e => e.DMDescripcion).HasColumnName("DMDescripcion");
            entity.Property(e => e.DMNombre).HasColumnName("DMNombre");
        });

        modelBuilder.Entity<DMPrioridad>(entity =>
        {
            entity.ToTable("DMPrioridad");

            entity.Property(e => e.DMPrioridadId).HasColumnName("DMPrioridadID");
            entity.Property(e => e.DMDescripcion).HasColumnName("DMDescripcion");
            entity.Property(e => e.DMNombre).HasColumnName("DMNombre");
        });

        modelBuilder.Entity<DMTarea>(entity =>
        {
            entity.ToTable("DMTarea");

            entity.HasIndex(e => e.DMCategoriaID, "IX_DMTarea_DMCategoriaID").IsUnique();

            entity.HasIndex(e => e.DMPrioridadID, "IX_DMTarea_DMPrioridadID").IsUnique();

            entity.Property(e => e.DMTareaID).HasColumnName("DMTareaID");
            entity.Property(e => e.DMCategoriaID).HasColumnName("DMCategoriaID");
            entity.Property(e => e.DMDescripcion).HasColumnName("DMDescripcion");
            entity.Property(e => e.DMFechaVencimiento).HasColumnName("DMFechaVencimiento");
            entity.Property(e => e.DMPrioridadID).HasColumnName("DMPrioridadID");
            entity.Property(e => e.DMTitulo).HasColumnName("DMTitulo");

            entity.HasOne(d => d.DMCategoria).WithOne(p => p.DMTarea).HasForeignKey<DMTarea>(d => d.DMCategoriaID);

            entity.HasOne(d => d.DMPrioridad).WithOne(p => p.DMTarea).HasForeignKey<DMTarea>(d => d.DMPrioridadID);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}