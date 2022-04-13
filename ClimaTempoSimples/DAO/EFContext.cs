using ClimaTempoSimples.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ClimaTempoSimples.DAO
{
    public class EFContext : DbContext
    {
        public EFContext() : base("EFConnectionString") { }

        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }*/

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<EFContext>(null);
            modelBuilder.Entity<Estado>().ToTable("Estado");
            modelBuilder.Entity<PrevisaoClima>().ToTable("PrevisaoClima");
            modelBuilder.Entity<Cidade>().ToTable("Cidade");
        }

        public DbSet<Estado> Estado { get; set; }
        public DbSet<PrevisaoClima> PrevisaoClima { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
    }
}