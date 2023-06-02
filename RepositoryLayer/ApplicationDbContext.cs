using DomainLayer.EntityMapper;
using DomainLayer.Models;
using DomainLayer.Models.Request;
using DomainLayer.Models.Response;
using Microsoft.EntityFrameworkCore;
using System;


namespace RepositoryLayer
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.ApplyConfiguration(new CustomerMap());

         base.OnModelCreating(modelBuilder);
      }
      public DbSet<CreateCountry> Cuountry { get; set; } 
      public DbSet<UpadteCountry> UpadteCountries { get; set; } 
      public DbSet<GetCountry> GetCountries { get; set; } 
      public DbSet<CustomerInfo> CustomerInfos { get; set; } 

    }
}
