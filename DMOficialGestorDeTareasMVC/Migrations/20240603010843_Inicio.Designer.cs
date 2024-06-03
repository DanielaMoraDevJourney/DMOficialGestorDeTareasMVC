﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DMOficialGestorDeTareasMVC.Migrations
{
    [DbContext(typeof(DMOficialGestorDeTareasMVCContext))]
    [Migration("20240603010843_Inicio")]
    partial class Inicio
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DMOficialGestorDeTareasMVC.Models.DMCategoria", b =>
                {
                    b.Property<int>("DMCategoriaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DMCategoriaID"));

                    b.Property<string>("DMDescripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DMNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DMCategoriaID");

                    b.ToTable("DMCategoria");
                });

            modelBuilder.Entity("DMOficialGestorDeTareasMVC.Models.DMPrioridad", b =>
                {
                    b.Property<int>("DMPrioridadID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DMPrioridadID"));

                    b.Property<string>("DMDescripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DMNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DMPrioridadID");

                    b.ToTable("DMPrioridad");
                });

            modelBuilder.Entity("DMOficialGestorDeTareasMVC.Models.DMTarea", b =>
                {
                    b.Property<int>("DMTareaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DMTareaID"));

                    b.Property<int>("DMCategoriaID")
                        .HasColumnType("int");

                    b.Property<string>("DMDescripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DMFechaVencimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("DMPrioridadID")
                        .HasColumnType("int");

                    b.Property<string>("DMTitulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DMTareaID");

                    b.HasIndex("DMCategoriaID")
                        .IsUnique();

                    b.HasIndex("DMPrioridadID")
                        .IsUnique();

                    b.ToTable("DMTarea");
                });

            modelBuilder.Entity("DMOficialGestorDeTareasMVC.Models.DMTarea", b =>
                {
                    b.HasOne("DMOficialGestorDeTareasMVC.Models.DMCategoria", "DMCategoria")
                        .WithOne("DMTarea")
                        .HasForeignKey("DMOficialGestorDeTareasMVC.Models.DMTarea", "DMCategoriaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DMOficialGestorDeTareasMVC.Models.DMPrioridad", "DMPrioridad")
                        .WithOne("DMTarea")
                        .HasForeignKey("DMOficialGestorDeTareasMVC.Models.DMTarea", "DMPrioridadID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DMCategoria");

                    b.Navigation("DMPrioridad");
                });

            modelBuilder.Entity("DMOficialGestorDeTareasMVC.Models.DMCategoria", b =>
                {
                    b.Navigation("DMTarea");
                });

            modelBuilder.Entity("DMOficialGestorDeTareasMVC.Models.DMPrioridad", b =>
                {
                    b.Navigation("DMTarea");
                });
#pragma warning restore 612, 618
        }
    }
}
