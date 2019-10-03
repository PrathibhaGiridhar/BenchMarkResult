using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchMarkResult.Models.MultipleDbContext
{
        public static class ProductMap
        {
            public static ModelBuilder MapProduct(this ModelBuilder modelBuilder, String schema)
            {
                var entity = modelBuilder.Entity<Products>();

                entity.ToTable("Products", schema);
               entity.ToTable("items", schema);

            entity.HasKey(p => new { p.Id });

                entity.Property(p => p.Id).UseNpgsqlIdentityColumn();

                return modelBuilder;
            }
        }
}
