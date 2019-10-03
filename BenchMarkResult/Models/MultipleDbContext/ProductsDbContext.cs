using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace BenchMarkResult.Models.MultipleDbContext
{
//    public class ProductsDbContext : DbContext
//    {
//        private readonly IConfiguration _config;

//        //public ProductsDbContext(IConfiguration config, DbContextOptions<ProductsDbContext> options)
//        //    : base(options)
//        //{
//        //    _config = config ?? throw new System.ArgumentNullException(nameof(config));
//        //}


//        public DbSet<Products> Products { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//                optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Username=postgres;Password=reladmin@123;Database=dotnetcore");
//            }
//        }

//        protected override void OnModelCreating(ModelBuilder builder)
//        {
//            builder.HasDefaultSchema("Product");
//            base.OnModelCreating(builder);
//        }


//    }


    public class ProductsDbContext : DbContext
    {
        public String ConnectionString { get; }

        public ProductsDbContext()
        {
            ConnectionString = @"Host = localhost; Port = 5432; Username = postgres; Password = reladmin@123; Database = dotnetcore";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionString);

            // this block forces map method invoke for each instance
          //  var builder = new ModelBuilder(new CoreConventionSetBuilder().CreateConventionSet());
            var builder = new ModelBuilder(new Microsoft.EntityFrameworkCore.Metadata.Conventions.ConventionSet());

            OnModelCreating(builder);

            optionsBuilder.UseModel(builder.Model);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.MapProduct("Product");

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Products> Products { get; set; }
    }
}
