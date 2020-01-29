using AtleticaCore.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtleticaCore.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Usuario>().HasData(
            new List<Usuario>() { 
                new Usuario() {ID = 1, NOME = "DANILO", EMAIL="danilo@gmail.com" } ,
                new Usuario() { ID = 2, NOME = "BIBI", EMAIL = "bibi@gmail.com" }
                }
            );
        }



    }
}
