// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using p2_ap1_wilkins_20170289.DAL;

namespace p2_ap1_wilkins_20170289.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20211108194646_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.12");

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
#pragma warning restore 612, 618
        }
    }
}
