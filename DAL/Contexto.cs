using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using p2_ap1_wilkins_20170289.Entidades;

namespace p2_ap1_wilkins_20170289.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Tareas> Tareas { get; set; }
        public DbSet<Proyectos> Proyectos{ get; set; }
       


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Data\ProyectosTareas.db"); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tareas>().HasData(new Tareas { TareaId = 1, TipoTarea = "Analisis", FechaCreacion = new DateTime(2021, 1, 15) });
            modelBuilder.Entity<Tareas>().HasData(new Tareas { TareaId = 2, TipoTarea = "Diseño", FechaCreacion = new DateTime(2021, 5, 20) });
            modelBuilder.Entity<Tareas>().HasData(new Tareas { TareaId = 3, TipoTarea = "Programación", FechaCreacion = new DateTime(2021, 11, 10) });
            modelBuilder.Entity<Tareas>().HasData(new Tareas { TareaId = 4, TipoTarea = "Prueba", FechaCreacion = new DateTime(2021, 12, 31) });
        }
    }
}