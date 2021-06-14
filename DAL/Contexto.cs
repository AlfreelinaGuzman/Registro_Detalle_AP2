using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Registro_Detalle_AP2.Models;


namespace Registro_Detalle_AP2.DAL
{

    public class Contexto : DbContext{

     public DbSet<Moras> Moras { get; set; }
     public DbSet<Personas> Personas { get; set; }
     public DbSet<Prestamos> Prestamos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     {
        optionsBuilder.UseSqlite(@"Data Source= Data/Registro.db");
      }   
    }
}