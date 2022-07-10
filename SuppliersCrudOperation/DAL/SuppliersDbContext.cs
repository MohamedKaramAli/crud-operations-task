using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SuppliersCrudOperation.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuppliersCrudOperation.DAL
{
    public class SuppliersDbContext:DbContext
    {

        private readonly IConfiguration configuration;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = configuration.GetValue<string>("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);

        }
        public SuppliersDbContext(DbContextOptions<SuppliersDbContext> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierType> SupplierTypes { get; set; }
        public DbSet<Governorate> Governorates { get; set; }
       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<SupplierType>().HasData(
       new SupplierType
       {
           Id = 1,
            Name = "Manufacturer"
       },
       new SupplierType
       {
           Id = 2,
           Name = "Importer"
       }, new SupplierType
       {
           Id = 3,
           Name = "Contractor"
       }, new SupplierType
       {
           Id = 4,
           Name = "Distriputer"
       });
        
        modelBuilder.Entity<Governorate>().HasData(
       new Governorate
       {
           Id = 1,
            Name = "Cairo",
       Order=1
       },
       new Governorate
       {
           Id = 2,
           Name = "Alex",
           Order=2
       }, new Governorate
{
    Id = 3,
    Name = "Contractor",
    Order=3
});
        }



    }
}
