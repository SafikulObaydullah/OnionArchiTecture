using DomainLayer.EntityMapper;
using DomainLayer.Models;
using DomainLayer.Models.Configuration;
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
      //public DbSet<CreateCountry> Cuountry { get; set; } 
      //public DbSet<UpadteCountry> UpadteCountries { get; set; } 
      //public DbSet<GetCountry> GetCountries { get; set; } 
      //public DbSet<CustomerInfo> CustomerInfos { get; set; }
      public DbSet<Activity> Activities { get; set; }
      public DbSet<CaseActivity> CaseActivities { get; set; }
      public DbSet<CaseCategory> CaseCategories { get; set; }
      public DbSet<CaseNature> CaseNatures { get; set; }
      public DbSet<CaseStatus> caseStatuses { get; set; }
      public DbSet<CaseType> CaseTypes { get; set; }  
      public DbSet<ConcernedPerson> Concerns { get; set; }  
      public DbSet<Court> Courts { get; set; }
      public DbSet<Department> Departments { get; set; } 
      public DbSet<Designation> DepartmentsDesignations { get;}
      public DbSet<MinistryOrDepartment> MinistryOrDepartments { get; set; }  
      public DbSet<Office> Offices { get; set; }
      public DbSet<UserType> UserTypes { get; set; }  

   }
}
