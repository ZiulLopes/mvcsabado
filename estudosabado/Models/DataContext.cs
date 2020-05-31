using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace estudosabado.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Movie> Movie { get; set; }

        public DataContext() : base("name=DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().ToTable("MOVIE");
            modelBuilder.Entity<Movie>().HasKey<int>(s => s.Id);
            modelBuilder.Entity<Movie>().Property(t => t.Id).HasColumnName("Id").HasColumnType("int").IsRequired();
            modelBuilder.Entity<Movie>().Property(t => t.NameMovie).HasColumnName("NAMEMOVIE").HasColumnType("varchar").IsRequired();
            modelBuilder.Entity<Movie>().Property(t => t.RateMovie).HasColumnName("RATEMOVIE").HasColumnType("decimal").IsRequired();
            modelBuilder.Entity<Movie>().Property(t => t.YearMovie).HasColumnName("YEARMOVIE").HasColumnType("int").IsRequired();
        }
    }
}