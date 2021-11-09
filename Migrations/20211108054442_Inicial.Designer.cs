﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using p2_ap1_wilkins_20170289.DAL;

namespace p2_ap1_wilkins_20170289.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20211108054442_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("p2_ap1_wilkins_20170289.Entidades.Proyectos", b =>
                {
                    b.Property<int>("ProyectoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<double>("TiempoTotal")
                        .HasColumnType("REAL");

                    b.HasKey("ProyectoId");

                    b.ToTable("Proyectos");
                });

            modelBuilder.Entity("p2_ap1_wilkins_20170289.Entidades.ProyectosDetalle", b =>
                {
                    b.Property<int>("ProyectosDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProyectoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Requerimiento")
                        .HasColumnType("TEXT");

                    b.Property<int>("TareaId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Tiempo")
                        .HasColumnType("REAL");

                    b.HasKey("ProyectosDetalleId");

                    b.HasIndex("ProyectoId");

                    b.HasIndex("TareaId");

                    b.ToTable("ProyectosDetalle");
                });

            modelBuilder.Entity("p2_ap1_wilkins_20170289.Entidades.Tareas", b =>
                {
                    b.Property<int>("TareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("TEXT");

                    b.Property<string>("TipoTarea")
                        .HasColumnType("TEXT");

                    b.HasKey("TareaId");

                    b.ToTable("Tareas");

                    b.HasData(
                        new
                        {
                            TareaId = 1,
                            FechaCreacion = new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TipoTarea = "Analisis"
                        },
                        new
                        {
                            TareaId = 2,
                            FechaCreacion = new DateTime(2021, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TipoTarea = "Diseño"
                        },
                        new
                        {
                            TareaId = 3,
                            FechaCreacion = new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TipoTarea = "Programación"
                        },
                        new
                        {
                            TareaId = 4,
                            FechaCreacion = new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TipoTarea = "Prueba"
                        });
                });

            modelBuilder.Entity("p2_ap1_wilkins_20170289.Entidades.ProyectosDetalle", b =>
                {
                    b.HasOne("p2_ap1_wilkins_20170289.Entidades.Proyectos", null)
                        .WithMany("Detalle")
                        .HasForeignKey("ProyectoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("p2_ap1_wilkins_20170289.Entidades.Tareas", "tareas")
                        .WithMany()
                        .HasForeignKey("TareaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tareas");
                });

            modelBuilder.Entity("p2_ap1_wilkins_20170289.Entidades.Proyectos", b =>
                {
                    b.Navigation("Detalle");
                });
#pragma warning restore 612, 618
        }
    }
}
