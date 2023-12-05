using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjEfCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace EjEfCore.DataAccess
{
    public class AcademiaDbContext : DbContext
    {
        public DbSet<Estudiante> Estudiantes { get; set; } // DbSet es una colección de entidades
        public AcademiaDbContext() 
        { 
            this.Database.EnsureDeleted(); // Elimina la base de datos si existe
            this.Database.EnsureCreated(); // Crea la base de datos si no existe
        }

        // Configuración de la conexión a la base de datos
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { 
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AcademiaDb");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudiante>(e =>
            {
                e.Property(p => p.Nombre).HasMaxLength(50);

                e.HasData(
                    new Estudiante()
                    {
                        Id = 1,
                        Nombre = "Juan",
                        Apellido = "Perez",
                        FechaNacimiento = new DateOnly(2000, 1, 1),
                        Legajo = 1234
                    },
                    new Estudiante()
                    {
                        Id = 2,
                        Nombre = "Maria",
                        Apellido = "Gomez",
                        FechaNacimiento = new DateOnly(2005, 3, 3),
                        Legajo = 1235
                    },
                    new Estudiante()
                    {
                        Id = 3,
                        Nombre = "Pedro",
                        Apellido = "Gonzalez",
                        FechaNacimiento = new DateOnly(2002, 2, 2),
                        Legajo = 1236
                    }
                );
            });
        }
    }
}
