using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceCity.Model
{
    public class CityContext : DbContext
    {
        public CityContext(DbContextOptions<CityContext> options) : base(options)
        {
        }
        public DbSet<CityItem> cityitem { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<CityItem>()
        //        .Property(i => i.Id)
        //        .ValueGeneratedNever();

        //    modelBuilder.Entity<CityItem>()
        //        .Property(i => i.Code)
        //        .HasColumnType("code");
        //}




        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    {
        //        optionsBuilder.UseSqlite("Data Source=CityDb.db");
        //    }
    }
}
