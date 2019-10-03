using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BenchMarkResult.Models.MultipleDbContext;
using Microsoft.EntityFrameworkCore;

namespace BenchMarkResult.Dal
{
    public class ProductsDal
    {
        public List<Products> GetProductsList_EF()
        {
            using (var db = new ProductsDbContext())
            {
                var aaaaa = db.Model.GetDefaultSchema();
                var assfff = db.Products.ToList();
                
                return db.Products.FromSqlRaw("select * from products").AsNoTracking().ToList();
            }
        }
    }
}
